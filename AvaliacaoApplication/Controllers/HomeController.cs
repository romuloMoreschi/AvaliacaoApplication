using AvaliacaoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AvaliacaoApplication.Repository.Contract;

namespace AvaliacaoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly string Baseurl = "https://localhost:44302/";
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
            var EquipInfo = new Equipamento();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Equipamentos/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EquipInfo = JsonConvert.DeserializeObject<Equipamento>(EmpResponse);
                }
                return View(EquipInfo);
            }
        }
        public async Task<IActionResult> Index()
        {
            List<Equipamento> EquipInfo = new List<Equipamento>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Equipamentos");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EquipInfo = JsonConvert.DeserializeObject<List<Equipamento>>(EmpResponse);
                }
                return View(EquipInfo);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(Equipamento equipamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/Equipamentos", equipamento);
                if (Res.IsSuccessStatusCode)
                {
                    TempData["MSG_S"] = "Registro salvo com sucesso!";
                    return View();
                }
                TempData["MSG_D"] = "Houve um problema!";
                return View();
            }
        }
        public async Task<IActionResult> ExcluirAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync($"api/Equipamentos/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    TempData["MSG_S"] = "Registro removido com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["MSG_D"] = "Houve um problema!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
