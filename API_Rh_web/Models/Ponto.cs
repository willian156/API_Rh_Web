using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Ponto
    {
        public ICollection<Vaga> VagaPonto { get; set; }
        public ICollection<Conhecimento> ConhecimentoPonto { get; set; }
        public int pontos { get; set; }
    }
}
