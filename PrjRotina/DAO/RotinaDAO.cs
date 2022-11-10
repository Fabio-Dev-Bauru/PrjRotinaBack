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
    public class RotinaDAO : IRotinaDAO
    {
        private readonly IMongoCollection<Rotina> _rotinas;

        public RotinaDAO(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _rotinas = database.GetCollection<Rotina>("rotinas");
        }

        public void Adicionar(Rotina rotina)
        {
            _rotinas.InsertOne(rotina);
        }

        public void Atualizar(Rotina rotinaAtualizada)
        {
            _rotinas.ReplaceOne(rotina => rotina.Id == rotinaAtualizada.Id, rotinaAtualizada);
        }

        public IEnumerable<Rotina> ListaRotina(string nome)
        {
            return _rotinas.Find(rotina => rotina.Nome.Contains(nome ?? string.Empty)).ToList();
        }

        public Rotina Buscar(string id)
        {
            var rotina = _rotinas.Find(rotina => rotina.Id == id).FirstOrDefault();

            if (rotina == null)
                rotina = new Rotina();

            return rotina;
        }

        public void Remover(string id)
        {
            _rotinas.DeleteOne(rotina => rotina.Id == id);
        }

        public IEnumerable<Rotina> ListaRotina(int pagina, string nome)
        {
            List<Rotina> obj = new();
            const int linhas = 3;

            if (pagina == 1)
            {
                obj = _rotinas.Find(rotina => rotina.Nome.Contains(nome ?? string.Empty)).Limit(3).ToList();
            }

            else
            {
                obj = _rotinas.Find(rotina => rotina.Nome.Contains(nome ?? string.Empty)).Skip((pagina * linhas) - linhas).ToList();
            }

            


                                


            return obj;

        }
    }
}
