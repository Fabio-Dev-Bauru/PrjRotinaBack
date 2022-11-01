using PrjRotina.Models;
using System.Collections.Generic;

namespace PrjRotina.DAO.Interfaces
{
    public interface IRotinaDAO
    {
        void Adicionar(Rotina rotina);

        void Atualizar(Rotina rotinaAtualizada);

        IEnumerable<Rotina> ListaRotina(string nome);

        Rotina Buscar(string id);

        void Remover(string id);
    }
}
