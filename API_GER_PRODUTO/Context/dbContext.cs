using API_GER_PRODUTO.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_GER_PRODUTO.Context
{
    public class dbContext: DbContext
    {

        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public string ConnectionString { get; set; }



        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }


        public DbSet<Models.Produto> Produto { get; set; }
        public DbSet<Models.Categoria> Categoria { get; set; }

    }
}
