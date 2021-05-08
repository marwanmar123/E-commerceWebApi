using AuthJWT.Data;
using AuthJWT.Models;
using AuthJWT.Repostory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepo<Product> _repo;
        private readonly ApplicationDbContext _db;


        public ProductController(IRepo<Product> repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }
        [HttpGet]
        //[Route("GetProducts")]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetItems();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var productsID = await _repo.GetItem(id);
            return Ok(productsID);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {

            await _db.SaveChangesAsync();
            var create = await _repo.AddItem(product);
            return Ok(create);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            await _repo.UpdateItem(product);

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
