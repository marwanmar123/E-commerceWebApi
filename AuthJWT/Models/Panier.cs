using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Panier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string ProductId { get; set; }
        public double Quantity { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public double Some()
        {
            return Quantity * Product.Prix;
        }
    }
}
