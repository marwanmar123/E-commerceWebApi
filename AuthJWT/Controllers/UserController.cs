using AuthJWT.Models;
using AuthJWT.Repostory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepo _repo;

        public UserController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repo.GetUsers();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var userId = await _repo.GetUser(id);
            return Ok(userId);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var create = await _repo.AddUser(user);
            return Ok(create);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            await _repo.UpdateUser(user);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var delete = await _repo.DeleteUser(id);
            return Ok();

        }
    }
}

