
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GER_PRODUTO.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "A Situação é obrigatória")]
        public string Situacao { get; set; }


        [Required(ErrorMessage = "Informe o ID da categoria.")]
        public int Id_Categoria { get; set; }


        public Produto()
        {

        }
        public Produto(string nome, string descricao, decimal preco, string situacao, int id_Categoria)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Situacao = situacao;
            Id_Categoria = id_Categoria;
        }


        public Produto( int id, string nome, string descricao, decimal preco, string situacao, int id_Categoria)
        {
            Id=id;
            Nome=nome;   
            Descricao=descricao;    
            Preco=preco;   
            Situacao=situacao;
            Id_Categoria = id_Categoria;

        }
        public Produto(string descricao, string situacao)
        {

            Descricao = descricao;
            Situacao= situacao;
        }

    


    }
}
