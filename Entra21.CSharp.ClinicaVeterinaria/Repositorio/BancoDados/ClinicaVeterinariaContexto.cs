using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados
{
    public class ClinicaVeterinariaContexto : DbContext
    {
        public DbSet<Raca> Racas { get; set; }
        public ClinicaVeterinariaContexto(
            DbContextOptions<ClinicaVeterinariaContexto> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Documentação: https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
            //Necessário instalar a ferramenta do dotnet ef core
            //dotnet tool install --global dotnet-ef

            //1a etapa criar a entidade Raca.cs
            //2a etapa criar o mapeamento da entidade para tabela RacaMapeamento.cs
            //3a etapa registrar mapeamento
            //4a etapa gerar a migration
            //5a etapa a migration poderá ser aplicada de duas formas:
            //executar comando para aplicar a migration sem a necessidade de executar a plicação
            //dotnet ef database update
            //executar a aplicação irá aplicar a migration

            modelBuilder.ApplyConfiguration(new RacaMapeamento());
        }
    }
}
