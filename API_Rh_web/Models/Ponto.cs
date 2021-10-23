using System;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Ponto
    {
        [Required]
        [Key]
        public int id_vaga { get; set; }
        [Required]
        public int id_Conhecimentos { get; set; }
        public int pontos { get; set; }
    }
}
