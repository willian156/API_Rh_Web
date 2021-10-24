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
        public int id_Conhecimentos { get; set; }
        public ICollection<Curriculo_Conhecimento> Curriculo_Conhecimento { get; set; }

        
    }
}
