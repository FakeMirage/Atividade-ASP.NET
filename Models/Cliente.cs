using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TEste.Models
{
    public class Cliente
    {


        [Required(ErrorMessage = "Informe o Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a Data de Nascimento")]
        public string dataNascimento { get; set; }

        public int id { get; set; }
    }
}
