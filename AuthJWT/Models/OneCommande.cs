using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class OneCommande
    {
        public string Id { get; set; }
        public string CommandId { get; set; }
        public string ProductId { get; set; }
        public float Price { get; set; }

        public Product Product { get; set; }
    }
}
