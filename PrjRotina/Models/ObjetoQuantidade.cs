using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.Models
{
    public class ObjetoQuantidade<T>
    {
        private const int VALOR_ZERO = 0;

        public ObjetoQuantidade()
        {
            Quantidade = VALOR_ZERO;
            Lista = new();
        }

        public long Quantidade { get; set; }
        public List<T> Lista { get; set; }
    }
}
