using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjRotina.DAO.Interfaces;
using PrjRotina.Models;
using PrjRotina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDAO _usuario;

        public UsuarioController(IUsuarioDAO usuarioDAO)
        {
            _usuario = usuarioDAO;
        }

        [HttpPost("Autenticar")]
        public async Task<ActionResult<Usuario>> Autenticar([FromBody] Usuario objeto)
        {
            try
            {
                Usuario usuarioLogado = _usuario.Autenticar(objeto);

                if (string.IsNullOrEmpty(usuarioLogado.Id))
                    return NotFound(new Retorno { Mensagem = "Usuário ou senha inválidos" });

                var token = await JWTService.GerarToken(usuarioLogado, false);

                return Ok(token);
            }
            catch
            {
                return BadRequest(new Retorno { Mensagem = "Não foi possível realizar esta operação, tente novamente mais tarde" });
            }
        }

        [HttpPost]
        public IActionResult Insere([FromBody] Usuario objeto)
        {
            _usuario.Adicionar(objeto);

            return Created("", objeto);
        }
    }
}
