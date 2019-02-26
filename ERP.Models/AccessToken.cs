using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
