using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Conhecimento
    {
        [Required]
        [Key]
        public int id_Conhecimentos { get; set; }
        public string nmConhecimento { get; set; }
        public string conDescricao { get; set; }
        public ICollection<Curriculo_Conhecimento> Curriculo_Conhecimento { get; set; }
        public ICollection<Ponto> Pontos { get; set; }
    }
}
