using API_GER_PRODUTO.Context;
using API_GER_PRODUTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GER_PRODUTO.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly dbContext _context;

        public CategoriaController(dbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("Categoria/CadastrarCategoria")]
        public async Task<IActionResult> CadastrarCategoria(string nome, string situacao)
        {

            var categoria = new Categoria(
                
                nome,
                situacao
                );

            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return Ok(categoria);
        }


        [HttpPut]
        [Route("Categoria/AtualizarCategoria")]
        public async Task<ActionResult> AtualizarCategoria(Categoria categoria)
        {

            try
            {
                var entityUpdate = await _context.Categoria.FirstOrDefaultAsync(s => s.Id == categoria.Id);

                entityUpdate.Nome = categoria.Nome;
                entityUpdate.Situacao = categoria.Situacao;

                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception)
            {
                return NotFound("Categoria não encontrada.");
            }
        }


        [HttpGet]
        [Route("Categoria/ListarCategoria")]
        public ActionResult<IEnumerable<Categoria>> ListarCategoria(string nomeCategoria, string situacaoCategoria)
        {

            var nomeParametro = new SqlParameter("@Nome", string.IsNullOrEmpty(nomeCategoria));
            var situacaoParametro = new SqlParameter("@Situacao", string.IsNullOrEmpty(situacaoCategoria));
            var result = _context.Categoria.FromSqlRaw(@"SELECT * FROM CATEGORIA WHERE NOME = @Nome AND SITUACAO = @Situacao", nomeParametro, situacaoParametro).ToList();
            if (result == null)
            {
                return NotFound("Categoria não encontrada.");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
