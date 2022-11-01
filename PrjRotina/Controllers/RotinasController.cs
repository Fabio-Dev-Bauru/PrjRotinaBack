using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrjRotina.DAO.Interfaces;
using PrjRotina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrjRotina.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RotinasController : ControllerBase
    {
        private IRotinaDAO _rotinas;

        public RotinasController(IRotinaDAO rotinasDAO)
        {
            _rotinas = rotinasDAO;
        }


        // GET: api/rotinas
        [HttpGet("lista/{nome?}")]
        public ActionResult ListaRotina(string nome)
        {
            var rotinas = _rotinas.ListaRotina(nome);   
            return Ok(rotinas);
        }

        // GET api/rotinas/{id}
        [HttpGet("{id}")]
        public IActionResult RetornaObjeto(string id)
        {
            var rotina = _rotinas.Buscar(id);

            return Ok(rotina);
        }

        // POST api/rotinas
        [HttpPost]
        public IActionResult Insere([FromBody] Models.InputModels.Rotina novaRotina)
        {
            var rotina = new Models.Rotina(novaRotina.Nome, novaRotina.Detalhes, Guid.NewGuid().ToString());

            _rotinas.Adicionar(rotina);

            return Created("", rotina);
        }

        // PUT api/rotinas/{id}
        [HttpPut]
        public IActionResult Atualiza([FromBody] Models.InputModels.Rotina rotinaAtualizada)
        {
            var rotina = _rotinas.Buscar(rotinaAtualizada.Id);

            if (rotina == null)
                return NotFound();

            rotina.AtualizarTarefa(rotinaAtualizada.Nome, rotinaAtualizada.Detalhes, rotinaAtualizada.Concluido);

            _rotinas.Atualizar(rotina);

            return Ok(rotina);
        }

        // DELETE api/rotinas/{id}
        [HttpDelete("{id}")]
        public IActionResult Deleta(string id)
        {
            var rotina = _rotinas.Buscar(id);

            if (rotina == null)
                return NotFound();

            _rotinas.Remover(id);

            return NoContent();
        }
    }
}
