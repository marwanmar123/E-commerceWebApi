using AuthJWT.Authentication;
using AuthJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuth _auth;

        public RegisterController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] Register register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.Register(register);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            //return Ok(new { token = result.Token, expirson = result.ExpiresOn });

            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.DoLogin(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }



        [HttpPost("role")]
        public async Task<IActionResult> AddRole([FromBody] RoleWork role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.AddRole(role);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(role);
        }
    }
}
