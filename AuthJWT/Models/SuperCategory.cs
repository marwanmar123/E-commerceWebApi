using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class SuperCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}
