using AuthJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Repostory
{
    public interface IRepo<Item>
    {
        Task<List<Item>> GetItems();
        Task<Item> GetItem(string id);
        Task<Item> AddItem(Item user);
        Task<int> DeleteItem(string id);
        Task UpdateItem(Item user);
    }
}
