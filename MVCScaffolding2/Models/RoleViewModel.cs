using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCScaffolding2.Models
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name="Naam")]
        public string Name { get; set; }

    }
}
