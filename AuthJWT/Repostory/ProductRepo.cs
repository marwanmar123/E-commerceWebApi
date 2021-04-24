using AuthJWT.Data;
using AuthJWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Repostory
{
    public class ProductRepo : IRepo<Product>
    {
        private readonly ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> AddItem(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteItem(string id)
        {
            var user = await _db.Products.FirstOrDefaultAsync(i => i.Id == id);
            _db.Products.Remove(user);
            var save = await _db.SaveChangesAsync();
            return save;
        }

        public async Task<Product> GetItem(string id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetItems()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task UpdateItem(Product user)
        {
            _db.Products.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
