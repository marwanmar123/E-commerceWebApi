using AuthJWT.Models;
using AuthJWT.Repostory;
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
    public class SuperCategoryController : ControllerBase
    {
        private readonly IRepo<SuperCategory> _repo;

        public SuperCategoryController(IRepo<SuperCategory> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var scats = await _repo.GetItems();
            return Ok(scats);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var catId = await _repo.GetItem(id);
            return Ok(catId);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SuperCategory super)
        {
            var create = await _repo.AddItem(super);
            return Ok(create);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] SuperCategory super)
        {
            await _repo.UpdateItem(super);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var delete = await _repo.DeleteItem(id);
            return Ok(delete);

        }
    }
}
