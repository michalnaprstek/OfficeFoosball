using System;
using Microsoft.AspNetCore.Identity;

namespace OfficeFoosball.DAL.Entities
{
    public class User : IdentityUser
    {
        public bool IsApproved { get; set; }    
    }
}
