using System;
using System.Collections.Generic;

#nullable disable

namespace Herfa.Models
{
    public partial class LoginFp
    {
        public decimal Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Roleid { get; set; }
    }
}
