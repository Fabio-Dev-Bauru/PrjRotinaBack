using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.Models.InputModels
{
    public class Rotina
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public string Detalhes { get; set; }

        public bool? Concluido { get; set; }
    }
}
