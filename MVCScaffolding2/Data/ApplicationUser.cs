using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCScaffolding2.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Straatnaam")]
        [MaxLength(100)]
        public string Straat { get; set; }
        [Display(Name = "Huis nummer")]
        [MaxLength(10)]
        public string HuisNr { get; set; }
    }
}
