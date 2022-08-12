using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    internal interface IRacaServico
    {
        void Cadastrar(string nome, string especie);
        List<Raca> ObterTodos();
    }
}
