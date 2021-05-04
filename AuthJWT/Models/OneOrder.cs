using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class OneOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }

        public Product Product { get; set; }
    }
}
