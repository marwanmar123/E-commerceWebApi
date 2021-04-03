using AuthJWT.JWTData;
using AuthJWT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthJWT.Authentication
{
    public class Auth : IAuth
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public Auth(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
        public async Task<TokenAuth> Register(Register register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) is not null)
                return new TokenAuth { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(register.Username) is not null)
                return new TokenAuth { Message = "Username is already registered!" };

            var user = new User
            {
                UserName = register.Username,
                Email = register.Email,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description}";

                return new TokenAuth { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwt(user);

            return new TokenAuth
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }


        public async Task<TokenAuth> DoLogin(Login token)
        {
            var tokenAuth = new TokenAuth();

            var user = await _userManager.FindByEmailAsync(token.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, token.Password))
            {
                tokenAuth.Message = "Email or Password is incorrect!";
                return tokenAuth;
            }

            var jwtSecurityToken = await CreateJwt(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            tokenAuth.IsAuthenticated = true;
            tokenAuth.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            tokenAuth.Email = user.Email;
            tokenAuth.Username = user.UserName;
            tokenAuth.ExpiresOn = jwtSecurityToken.ValidTo;
            tokenAuth.Roles = rolesList.ToList();

            return tokenAuth;
        }



        public async Task<string> AddRole(RoleWork role)
        {
            var user = await _userManager.FindByIdAsync(role.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(role.RoleName))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, role.RoleName))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, role.RoleName);

            return result.Succeeded ? string.Empty : "Error";
        }

        private async Task<JwtSecurityToken> CreateJwt(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
