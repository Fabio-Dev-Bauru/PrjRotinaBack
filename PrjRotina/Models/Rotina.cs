using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.Models
{
    public class Rotina
    {
        public Rotina(string nome = "", string detalhes = "", string id = "")
        {
            Id = id;
            Nome = nome;
            Detalhes = detalhes;
            Concluido = false;
            DataCadastro = DateTime.Now;
            DataConclusao = null;
            Quantidade = 0;
        }

        public string Id { get; private set; }

        public string Nome { get; private set; }

        public string Detalhes { get; private set; }

        public bool Concluido { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public DateTime? DataConclusao { get; private set; }

        public int Quantidade { get; set; }


        public void AtualizarTarefa(string nome, string detalhes, bool? concluido = false)
        {
            Nome = nome;
            Detalhes = detalhes;
            Concluido = concluido ?? false;
            DataConclusao = Concluido ? DateTime.Now : null;
        }
    }
}
