using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades
{
    public class Veterinario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Crmv { get; set; }
        public int Idade { get; set; }
        public decimal Salario { get; set; }
        public bool Empregado { get; set; }
    }
}
