using AuthJWT.Data;
using AuthJWT.Models;
using AuthJWT.Repostory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext Db)
        {
            _db = Db;
        }


        [HttpGet("Categories")]
        public async Task<IActionResult> Catgr()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var result = await _db.Products.Where(x => x.CategoryId == id).OrderByDescending(y => y.Date).ToListAsync();
            return Ok(result);
        }
    }
}
