using AvaliacaoApplication.Models;
using AvaliacaoApplication.Repository.Contract;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AvaliacaoApplication.Repository
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly string Baseurl = "https://localhost:44302/";
        private HttpClient Initialize()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Baseurl)
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public async Task<bool> AtualizarAsync(Equipamento equipamento, int id)
        {
            HttpResponseMessage Res = await Initialize().PutAsJsonAsync($"api/Equipamentos/{id}", equipamento);
            if (Res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CadastrarAsync(Equipamento equipamento)
        {
            HttpResponseMessage Res = await Initialize().PostAsJsonAsync("api/Equipamentos", equipamento);
            if (Res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            HttpResponseMessage Res = await Initialize().DeleteAsync($"api/Equipamentos/{id}");
            if (Res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Equipamento> ObterEquipamentoAsync(int id)
        {
            var EquipInfo = new Equipamento();
            HttpResponseMessage Res = await Initialize().GetAsync($"api/Equipamentos/{id}");
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                EquipInfo = JsonConvert.DeserializeObject<Equipamento>(EmpResponse);
            }
            return EquipInfo;
        }

        public async Task<ICollection<Equipamento>> ObterTodosEquipamentosAsync()
        {
            List<Equipamento> EquipInfo = new List<Equipamento>();

            HttpResponseMessage Res = await Initialize().GetAsync("api/Equipamentos");
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                EquipInfo = JsonConvert.DeserializeObject<List<Equipamento>>(EmpResponse);
            }

            return EquipInfo;
        }
    }
}
