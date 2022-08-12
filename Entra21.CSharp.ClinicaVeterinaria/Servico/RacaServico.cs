using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    //A classe RacaServico irá implementar a interface IRacaServico,
    //ou seja deverá honrar as cláusulas definidos na interface (contrato)
    public class RacaServico : IRacaServico
    {
        private readonly RacaRepositorio _racaRepositorio;

        //Construir: Construir o objeto de RacaServico com o minimo para a correta execução

        public RacaServico(ClinicaVeterinariaContexto contexto)
        {
            _racaRepositorio = new RacaRepositorio(contexto);
        }
        public void Cadastrar(string nome, string especie)
        {
            var raca = new Raca();
            raca.Nome = nome;
            raca.Especie = especie;

            _racaRepositorio.Cadastrar(raca);
            Console.WriteLine($"Nome: {nome} espécie: {especie}");
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }
    }
}
