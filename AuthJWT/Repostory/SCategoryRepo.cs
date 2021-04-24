using AuthJWT.Data;
using AuthJWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Repostory
{
    public class SCategoryRepo : IRepo<SuperCategory>
    {
        private readonly ApplicationDbContext _db;

        public SCategoryRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<SuperCategory> AddItem(SuperCategory superCategory)
        {
            await _db.SuperCategories.AddAsync(superCategory);

            await _db.SaveChangesAsync();
            return superCategory;
        }

        public async Task<int> DeleteItem(string id)
        {
            var user = await _db.SuperCategories.FirstOrDefaultAsync(i => i.Id == id);
            _db.SuperCategories.Remove(user);
            var save = await _db.SaveChangesAsync();
            return save;
        }

        public async Task<SuperCategory> GetItem(string id)
        {
            return await _db.SuperCategories.FindAsync(id);
        }

        public async Task<List<SuperCategory>> GetItems()
        {
            return await _db.SuperCategories.ToListAsync();
        }

        public async Task UpdateItem(SuperCategory superCategory)
        {
            _db.SuperCategories.Update(superCategory);
            await _db.SaveChangesAsync();
        }
    }
}
