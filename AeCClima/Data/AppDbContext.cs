using AeCClima.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AeCClima.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<Clima> Climas { get; set; }

        public DbSet<WeatherAirport> WeatherAirports { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherData>()
                .HasMany(w => w.Clima)
                .WithOne()
                .HasForeignKey("WeatherDataId");
            modelBuilder.Entity<Clima>()
                .Property<int>("WeatherDataId");

            modelBuilder.Entity<WeatherAirport>(entity =>
            {

                entity.HasKey(e => e.Id);  // Definindo a chave primária

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();  // Configura auto-incremento

                entity.Property(e => e.CodigoIcao)
                     .HasColumnName("codigo_icao")
                     .HasMaxLength(4)
                     .IsRequired();

                entity.Property(e => e.CondicaoDesc)
                    .HasColumnName("condicao_desc")
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.PressaoAtmosferica)
                    .HasColumnName("pressao_atmosferica")
                    .IsRequired();

                entity.Property(e => e.DirecaoVento)
                    .HasColumnName("direcao_vento")
                    .IsRequired();

                entity.Property(e => e.AtualizadoEm)
                    .HasColumnName("atualizado_em")
                    .IsRequired();

                entity.HasIndex(e => e.CodigoIcao)
                    .HasDatabaseName("IX_CodigoIcao");
            });

        }


    }
}
