using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Prix { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
