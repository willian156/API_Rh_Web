using System;
using System.ComponentModel.DataAnnotations;

namespace API_Rh_web.Models
{
    public class Vaga_curriculo
    {
        [Required]
        [Key]
        public int id_vaga { get; set; }
        public Vaga Vaga { get; set; }
        [Required]
        public int id_curriculo { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
