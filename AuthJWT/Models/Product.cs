using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public float Prix { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }
        public string CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
