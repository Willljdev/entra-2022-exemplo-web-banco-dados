using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels
{
    public class RacaViewModel
    {
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(4, ErrorMessage = "{0} nome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name ="Espécie")]
        [Required(ErrorMessage ="Selecione uma {0}")]
        public string Especie { get; set; }
    }
}