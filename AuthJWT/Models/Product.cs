using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Prix { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
