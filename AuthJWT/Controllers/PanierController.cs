using AuthJWT.Data;
using AuthJWT.Models;
using AuthJWT.Repostory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanierController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public PanierController(ApplicationDbContext Db, UserManager<User> userManager)
        {
            _db = Db;
            _userManager = userManager;
        }





        [HttpGet("AllPanier")]
        public async Task<IActionResult> Get()
        {
            var panies = await _db.Paniers.ToListAsync();
            return Ok(panies);
        }


        [HttpGet("PanierUser")]
        public async Task<IActionResult> GetPanierUser(string userId)
        {

            var panier = await _db.Paniers.Where(p => p.UserId == userId).ToListAsync();

            return Ok(panier);
        }

        [HttpPost("AddToPanier")]
        public async Task<IActionResult> AddPanier(string IdPrdct, Login login, float Q)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            //var ProductId = _db.Products.SingleOrDefault(p => p.Id == IdPrdct);
            //var qantity = _db.Paniers.SingleOrDefault(q => q.Quantity == Q);
            //var p = new Panier();


            var panier = await _db.Paniers.SingleOrDefaultAsync(p => p.ProductId == IdPrdct && p.UserId == user.Id);
            if (panier == null)
            {
                panier = new Panier
                {
                    UserId = user.Id,
                    ProductId = IdPrdct,
                    Quantity = Q
                    //TotalPrice = qantity.Quantity * ProductId.Prix
                };
                await _db.Paniers.AddAsync(panier);
            }
            else
            {
                panier.Quantity++;


            }
            await _db.SaveChangesAsync();

            return Ok(panier);
        }

        //[HttpGet("TotalPrice")]
        //public async Task<IActionResult> TotalPrice(string userId)
        //{
        //    //SumAsync(n => (n.Some()))
        //    var TP = await _db.Paniers.Where(p => p.UserId == userId).Include(n => n.Product).SumAsync(n => (n.Quantity * _product.Prix));
        //    return Ok(TP);
        //}

        [HttpPost("DeleteFromPanier")]
        public async Task<IActionResult> DeletePanier(string userId)
        {

            var panier = _db.Paniers.Where(p => p.UserId == userId).ToList();

            foreach (var a in panier)
            {
                _db.Remove(a);
            }
            await _db.SaveChangesAsync();

            return Ok(panier);
        }

    }
}
