using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Curriculo
    {
        [Required]
        [Key]
        public int id_curriculo { get; set; }
        public string nmPessoa { get; set; }
        public string pessDescricao { get; set; }
        public ICollection<Conhecimento> Conhecimento { get; set; }
        public ICollection<Vaga> Vaga { get; set; }

        
    }
}
