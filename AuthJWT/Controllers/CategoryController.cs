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
    public class CategoryController : ControllerBase
    {
        private readonly IRepo<Category> _repo;

        public CategoryController(IRepo<Category> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _repo.GetItems();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var categoriesID = await _repo.GetItem(id);
            return Ok(categoriesID);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var create = await _repo.AddItem(category);
            return Ok(create);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Category category)
        {
            await _repo.UpdateItem(category);

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
