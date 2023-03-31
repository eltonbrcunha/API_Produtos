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
    public class ProdutoController : Controller
    {
        private readonly dbContext _context;

        public ProdutoController(dbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("Produto/CadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto(string nome, string descricao,decimal preco,string situacao, int idcategoria)
        {

            var produto = new Produto(

                nome,
                descricao,
                preco,
                situacao,
                idcategoria
                );

            _context.Add(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }


        [HttpPut]
        [Route("Produto/AtualizarProduto")]
        public async Task<ActionResult> AtualizarProduto(Produto produto)
        {

            try
            {
                var entityUpdate = await _context.Produto.FirstOrDefaultAsync(s => s.Id == produto.Id);

                entityUpdate.Nome = produto.Nome;
                entityUpdate.Descricao = produto.Descricao;
                entityUpdate.Preco = produto.Preco;
                entityUpdate.Situacao = produto.Situacao;
                entityUpdate.Id_Categoria=produto.Id_Categoria;

                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception)
            {
                return NotFound("Produto não encontrado.");
            }
        }



        [HttpGet]
        [Route("Produto/ListarProduto")]
        public ActionResult<IEnumerable<Produto>> ListarProduto(string nomeCategoriaProduto, string descricaoProduto, string situacaoProduto)
        {
            var nomeCategoriaParametro = new SqlParameter()
            {
                ParameterName = "@NomeCategoria",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = nomeCategoriaProduto


            };
            var descricaoProdutoParametro = new SqlParameter()
            {
                ParameterName = "@DescricaoProduto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = descricaoProduto


            };

            var situacaoProdutoParametro = new SqlParameter()
            {
                ParameterName = "@SituacaoProduto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = situacaoProduto


            };

            var result = _context.Produto.FromSqlRaw(@"SELECT P.ID,P.NOME,P.DESCRICAO,P.PRECO,P.SITUACAO, ID_CATEGORIA From PRODUTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA=C.ID 
WHERE DESCRICAO=@DescricaoProduto AND c.Nome=@NomeCategoria AND p.SITUACAO=@SituacaoProduto", descricaoProdutoParametro, nomeCategoriaParametro, situacaoProdutoParametro).ToList();
            if (result == null)
            {
                return NotFound("Produto não encontrado.");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
