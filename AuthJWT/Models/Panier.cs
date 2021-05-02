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
        public float Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        //public float Price()
        //{
        //    return Quantity * Product.Prix;
        //}
    }
}
