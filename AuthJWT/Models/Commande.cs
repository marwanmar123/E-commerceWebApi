using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Commande
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }

        public ICollection<OneCommande> OneCommande { get; set; }
    }
}
