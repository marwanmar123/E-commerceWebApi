using AuthJWT.Data;
using AuthJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        public OrderController(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost("DoOrder")]
        public async Task<IActionResult> Order(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var Nmbr = _db.Paniers.Where(n => n.UserId == user.Id).ToList().Count;
            if (Nmbr == 0) return Ok("panier est vide");

            IList<Panier> ListPanier = _db.Paniers.Where(l => l.UserId == user.Id).Include(p => p.Product).ToList();
            var tp = await _db.Paniers.Where(p => p.UserId == user.Id).Include(n => n.Product).SumAsync(n => (n.TotalPrice));

            Order order = new Order
            {
                UserId = user.Id,
                Date = DateTime.Now,
                OrderStateId = "3",
                TotalePrice = tp
            };
            _db.Orders.Add(order);
            _db.SaveChanges();

            foreach (Panier p in ListPanier)
            {
                OneOrder oneOrder = new OneOrder
                {
                    OrderId = order.Id,
                    ProductId = p.ProductId,
                    Price = p.Product.Prix,
                    Quantity = p.Quantity
                };
                await _db.OneOrders.AddAsync(oneOrder);

            }
            await _db.SaveChangesAsync();

            var panier = _db.Paniers.Where(p => p.UserId == user.Id).ToList();
            if (panier.Count > 0)
            {
                _db.Paniers.RemoveRange(panier);
                await _db.SaveChangesAsync();
            }

            return Ok(order);
        }

        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(string Id)
        {
            var order = await _db.Orders.FindAsync(Id);
            order.OrderStateId = "1";
            await _db.SaveChangesAsync();
            return Ok(order);
        }
    }
}
