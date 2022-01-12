using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EternaTemplateFullStack.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength:25)]
        public string Fullname { get; set; }
    }
}
