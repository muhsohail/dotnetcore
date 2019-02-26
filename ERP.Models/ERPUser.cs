using System;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class ERPUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
