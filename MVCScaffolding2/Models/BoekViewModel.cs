using Microsoft.AspNetCore.Mvc.Rendering;
using MVCScaffolding2.Models.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCScaffolding2.Models
{
    public class BoekViewModel : Boek
    {
        [Display(Name ="Selecteer een genre")]
        public IEnumerable<SelectListItem> Genres { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("none","none"),
            new SelectListItem("Science-fictie","Science-fictie"),
            new SelectListItem("Actie","Actie"),
            new SelectListItem("Drama","Drama"),
            new SelectListItem("Non-fictie","Non-fictie")
        };
    }
}
