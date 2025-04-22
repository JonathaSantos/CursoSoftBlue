using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModeloNet6.Models;
using System.Collections.Generic;

namespace ModeloNet6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("", ServerVersion.AutoDetect(""));
        //}
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Midia> Midias { get; set; }


        private void ConfigureUser(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(p => p.nome)
                .IsUnique();
        }
    }
}
