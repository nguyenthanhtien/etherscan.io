using Etherscan.Entity;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Etherscan.Data
{
    public class EtherscanDbContext : DbContext
    {
        public DbSet<Token> Token { get; set; }

        public EtherscanDbContext(DbContextOptions<EtherscanDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
