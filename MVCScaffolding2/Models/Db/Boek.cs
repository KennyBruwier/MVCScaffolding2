using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCScaffolding2.Models.Db
{
    public class Boek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Titel")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Display(Name = "Uitgeverij")]
        [MaxLength(100)]
        public string Publisher { get; set; }
        [Display(Name = "Auteur")]
        [MaxLength(100)]
        public string Auteur { get; set; }
        [Display(Name = "Aantal bladzijdes")]
        public int AantalBlz { get; set; }
        [Display(Name = "Taal")]
        [MaxLength(100)]
        public string Taal { get; set; }
        [Display(Name = "Genre")]
        public string Genre { get; set; }
    }
}
