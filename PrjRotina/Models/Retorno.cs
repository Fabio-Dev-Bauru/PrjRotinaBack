using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.Models
{
    public class Retorno
    {
        public Retorno()
        {
            Mensagem = string.Empty;
        }

        public string Mensagem { get; set; }
    }
}
