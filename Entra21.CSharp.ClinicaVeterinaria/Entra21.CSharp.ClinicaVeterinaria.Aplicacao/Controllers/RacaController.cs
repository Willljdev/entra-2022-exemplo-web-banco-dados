using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    //Dois pontos Herança(mais para frente)
    public class RacaController : Controller
    {
        private readonly IRacaServico _racaServico;


        //Construtor: objetivo construir o objeto RacaController,
        //com o mínimo necessário para o funcionamento correto
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }
        /// <summary>
        /// Endpoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        //[Route("/raca")]
        [HttpGet("/raca")]

        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            //Passar informação do c# para o Html
           // ViewBag.Racas = racas;

            return View("Index", racas);
        }

        //[Route("/raca/cadastrar")]
        [HttpGet("/raca/cadastrar")]

        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();
            ViewBag.Especies = especies;

            var racaCadastrarViewModel = new RacaCadastrarViewModel();

            return View();
        }

        //[Route("/raca/cadastrar")]
        [HttpPost("/raca/cadastrar")]

        public IActionResult Cadastrar(
            [FromForm] RacaCadastrarViewModel racaCadastrarViewModel)
            
        {
            //Valida o parâmetro recebido na Action se é inválido
            if(!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();
                return View(racaCadastrarViewModel);
            }

            _racaServico.Cadastrar(racaCadastrarViewModel);
            return RedirectToAction("Index");
        }

        //[Route("/raca/apagar")]
        [HttpGet("/raca/apagar")]

        public IActionResult Apagar([FromQuery]int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/editar")]
        //[Route("/raca/editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Especies = especies;

            var racaEditarViewmodel = new RacaEditarViewModel()
            {
               Id = raca.Id,
               Nome = raca.Nome,
               Especie = raca.Nome
            };

            return View("Editar", racaEditarViewmodel);
        }

        [HttpPost]
        [Route("/raca/Editar")]
        public IActionResult Editar(
            [FromForm] RacaEditarViewModel racaEditarViewModel)
            
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();
                return View(racaEditarViewModel);
            }
            _racaServico.Editar(racaEditarViewModel);

            return RedirectToAction("Index");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>()
                            .OrderBy(x => x)
                            .ToList();
        }
    }
}
