using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    //DB First: Criar uma aplicação onde o banco de dados já existe
    //Code First: Criar um banco de dados apartir de uma aplicação existente
    //Seed: Alimentar o banco de dados com registros
    //Migration: representação do mapeamento que será aplicado no banco de dados
    //Mapeamento: representação da entidade em tabelas, colunas, indices...
    internal class RacaMapeamento : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("racas");

            builder.HasKey(x => x.Id).HasName("Id");

            builder.Property(x => x.Especie)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired() // not null
                .HasColumnName("especie");

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .HasColumnName("nome")
                .IsRequired();

            builder.HasData(new Raca
            {
                Id = 1,
                Nome = "Frajola",
                Especie = "Gato"
            },
            new Raca
            {
                Id=2,
                Nome = "Piupiu",
                Especie = "Capivara"
            });
        }

        
    }
}
