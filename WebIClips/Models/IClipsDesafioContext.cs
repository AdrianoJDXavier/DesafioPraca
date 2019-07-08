using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebIClips.Models
{
    public partial class IClipsDesafioContext : DbContext
    {
        public IClipsDesafioContext()
        {
        }

        public IClipsDesafioContext(DbContextOptions<IClipsDesafioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pracas> Pracas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IClipsDesafio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pracas>(entity =>
            {
                entity.HasKey(e => e.IdPraca);

                entity.Property(e => e.IdPraca).HasColumnName("idPraca");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado");

                entity.Property(e => e.Praca)
                    .IsRequired()
                    .HasColumnName("praca");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("sigla")
                    .HasMaxLength(3);
            });
        }
    }
}
