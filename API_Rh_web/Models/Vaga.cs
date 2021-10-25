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
        public ICollection<Curriculo> Curriculo { get; set; }
        public ICollection<Conhecimento> Conhecimento { get; set; }
    }
}
