using PrjRotina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.DAO.Interfaces
{
    public interface IUsuarioDAO
    {
        void Adicionar(Usuario usuario);

        void Atualizar(string id, Usuario usuarioAtualizado);

        IEnumerable<Usuario> Buscar();

        Usuario Buscar(string id);

        Usuario Autenticar(Usuario usuario);

        void Remover(string id);
    }
}
