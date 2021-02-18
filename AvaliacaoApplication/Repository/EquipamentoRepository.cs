using AvaliacaoApplication.Models;
using AvaliacaoApplication.Repository.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public void Atualizar(Equipamento equipamento)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(Equipamento equipamento)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int Id)
        {
            throw new System.NotImplementedException();
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

        public ICollection<Equipamento> ObterTodosEquipamentos()
        {
            throw new System.NotImplementedException();
        }
    }
}
