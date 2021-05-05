using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string OrderStateId { get; set; }
        public float TotalePrice { get; set; }

        public OrderState OrderState { get; set; }
        public ICollection<OneOrder> OneOrder { get; set; }

    }
}
