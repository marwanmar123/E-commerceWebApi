using AuthJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Repostory
{
    public interface IRepo
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string id);
        Task<User> AddUser(User user);
        Task<int> DeleteUser(string id);
        Task UpdateUser(User user);
    }
}
