using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Rh_web.Models
{
    public class Curriculo_Conhecimento
    {
        [Required]
        [Key]
        public int id_Curriculo { get; set; }
        [Required]
        public int id_Conhecimento { get; set; }
    }
}
