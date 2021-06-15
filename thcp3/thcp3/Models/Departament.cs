using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thcp3.Models
{
    public class Departament
    {
        [Key]
        public int DepartamentId { get; set; }
        [Display(Name ="Nombre")]
        public string DepartamentName { get; set; }

    }
}
