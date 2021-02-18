using AvaliacaoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AvaliacaoApplication.Repository.Contract;

namespace AvaliacaoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEquipamentoRepository _equipamentRepository;

        public HomeController(IEquipamentoRepository equipamentRepository)
        {
            _equipamentRepository = equipamentRepository;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public async Task<IActionResult> DetalhesAsync(int id)
        {
            return View(await _equipamentRepository.ObterEquipamentoAsync(id));
        }
        public async Task<IActionResult> AtualizarAsync(int id)
        {
            var EquipInfo = await _equipamentRepository.ObterEquipamentoAsync(id);
            return View(EquipInfo);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _equipamentRepository.ObterTodosEquipamentosAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(Equipamento equipamento)
        {
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
