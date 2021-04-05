using AuthJWT.Data;
using AuthJWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Repostory
{
    public class UserRepo : IRepo
    {
        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUser(string id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(i => i.Id == id);
            _db.Users.Remove(user);
            var save = await _db.SaveChangesAsync();
            return save;
        }

        public async Task<User> GetUser(string id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
