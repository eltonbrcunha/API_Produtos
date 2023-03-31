using System.ComponentModel.DataAnnotations;

namespace API_GER_PRODUTO.Models
{
    public class Categoria
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "A situação é obrigatória")]
        public string Situacao { get; set; }

        public Categoria() 
        { 
        
        } 
        public Categoria(string nome, string situacao)
        {
            Nome=nome; 
            Situacao=situacao;

        }

        public Categoria(int id,string nome, string situacao)
        {
            Id = id;
            Nome = nome;
            Situacao = situacao;

        }
    }
}
