using AvaliacaoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AvaliacaoApplication.Repository.Contract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AvaliacaoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEquipamentoRepository _equipamentRepository;
        private readonly IEstadosRepository _estadosRepository;

        public HomeController(IEquipamentoRepository equipamentRepository, IEstadosRepository estadosRepository)
        {
            _equipamentRepository = equipamentRepository;
            _estadosRepository = estadosRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _equipamentRepository.ObterTodosEquipamentosAsync());
        }
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Estados = new SelectList(await _estadosRepository.ObterTodosEstadosAsync(), "Sigla", "Nome");
            return View();
        }
        public async Task<IActionResult> Detalhes(int id)
        {
            return View(await _equipamentRepository.ObterEquipamentoAsync(id));
        }
        public async Task<IActionResult> Atualizar(int id)
        {
            ViewBag.Estados = new SelectList(await _estadosRepository.ObterTodosEstadosAsync(), "Sigla", "Nome");
            var EquipInfo = await _equipamentRepository.ObterEquipamentoAsync(id);
            return View(EquipInfo);
        }
        public async Task<IActionResult> EditarAsync(Equipamento equipamento, int id)
        {
            if (await _equipamentRepository.AtualizarAsync(equipamento, id))
            {
                TempData["MSG_S"] = "Registro salvo com sucesso!";
                return new RedirectResult(nameof(Atualizar));
            }
            TempData["MSG_D"] = "Houve um problema!";

            ViewBag.Estados = new SelectList(await _estadosRepository.ObterTodosEstadosAsync(), "Sigla", "Nome");
            var EquipInfo = await _equipamentRepository.ObterEquipamentoAsync(id);
            return new RedirectResult(nameof(Atualizar));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(Equipamento equipamento)
        {
            ViewBag.Estados = new SelectList(await _estadosRepository.ObterTodosEstadosAsync(), "Sigla", "Nome");

            if (await _equipamentRepository.CadastrarAsync(equipamento))
            {
                TempData["MSG_S"] = "Registro salvo com sucesso!";
                return View();
            }
            TempData["MSG_D"] = "Houve um problema!";
            return View();
        }
        public async Task<IActionResult> ExcluirAsync(int id)
        {
            if (await _equipamentRepository.ExcluirAsync(id))
            {
                TempData["MSG_S"] = "Registro removido com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["MSG_D"] = "Houve um problema!";

            return RedirectToAction(nameof(Index));
        }
    }
}
