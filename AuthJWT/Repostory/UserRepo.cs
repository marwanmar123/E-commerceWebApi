using AuthJWT.Data;
using AuthJWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthJWT.Repostory
{
    public class UserRepo : IRepo<User>
    {
        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> AddItem(User user)
        {
            await _db.Users.AddAsync(user);
            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim("uid", user.Id)
            //};
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteItem(string id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(i => i.Id == id);
            _db.Users.Remove(user);
            var save = await _db.SaveChangesAsync();
            return save;
        }

        public async Task<User> GetItem(string id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<List<User>> GetItems()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task UpdateItem(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
