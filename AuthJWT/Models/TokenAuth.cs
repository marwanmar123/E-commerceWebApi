using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class TokenAuth
    {
        public string Username { get; set; }

        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
