using MongoDB.Driver;
using PrjRotina.DAO.Config.Interface;
using PrjRotina.DAO.Interfaces;
using PrjRotina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioDAO(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _usuarios = database.GetCollection<Usuario>("usuarios");
        }

        public void Adicionar(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
        }

        public void Atualizar(string id, Usuario usuarioAtualizado)
        {
            _usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioAtualizado);
        }

        public Usuario Autenticar(Usuario usuario)
        {
            Usuario objetoBanco = _usuarios.Find(x => x.Login == usuario.Login && x.Senha == usuario.Senha).FirstOrDefault();

            if (objetoBanco == null)
                objetoBanco = new Usuario();

            return objetoBanco;
        }

        public IEnumerable<Usuario> Buscar()
        {
            return _usuarios.Find(usuario => true).ToList();
        }

        public Usuario Buscar(string id)
        {
            return _usuarios.Find(usuario => usuario.Id == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _usuarios.DeleteOne(usuario => usuario.Id == id);
        }
    }
}
