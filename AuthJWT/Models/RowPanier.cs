using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class RowPanier
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public double Quantity { get; set; }
        public string PanierId { get; set; }
        public Product Product { get; set; }
        public double Some()
        {
            return Quantity * Product.Prix;
        }
    }
}
