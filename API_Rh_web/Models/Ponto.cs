using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Ponto
    {
        [Required]
        [Key]
        public int id_Pontos { get; set; }

        public int id_vaga { get; set; }

        public int id_Conhecimentos { get; set; }
        public int pontos { get; set; }

        public Vaga Vaga { get; set; }
        public Conhecimento Conhecimento { get; set; }
    }
}
