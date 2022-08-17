using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    //Dois pontos Herança(mais para frente)
    public class RacaController : Controller
    {
        private readonly RacaServico _racaServico;


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
        [Route("/raca")]
        [HttpGet]

        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            //Passar informação do c# para o Html
            ViewBag.Racas = racas;

            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]

        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();
            ViewBag.Especies = especies;
            return View();
        }

        [Route("/raca/registrar")]
        [HttpPost]

        public IActionResult Registrar(
            [FromForm] string nome,
            [FromForm] string especie)
        {
            _racaServico.Cadastrar(nome, especie);
            return RedirectToAction("Index");
        }

        [Route("/raca/apagar")]
        [HttpGet]

        public IActionResult Apagar([FromQuery]int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/raca/editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especie = especies;

            ViewBag.Raca = raca;

            return View("Editar");
        }

        [HttpPost]
        [Route("/raca/alterar")]
        public IActionResult Alterar(
            [FromForm] int id,
            [FromForm] string nome,
            [FromForm] string especie)
        {
            _racaServico.Alterar(id, nome, especie);

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
