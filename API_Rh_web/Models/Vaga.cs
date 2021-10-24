using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Vaga
    {
        [Required]
        [Key]
        public int id_vaga { get; set; }
        public string nmVaga { get; set; }
        public string descricao { get; set; }
        [Required]
        public int id_Conhecimentos { get; set; }
        [Required]
        public int id_curriculo { get; set; }
        public ICollection<Vaga_curriculo> Vaga_curriculo { get; set; }
        public ICollection<Ponto> Pontos { get; set; }
    }
}
