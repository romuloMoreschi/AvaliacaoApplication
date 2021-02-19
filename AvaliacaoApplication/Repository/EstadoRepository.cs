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
    public class EstadoRepository : IEstadosRepository
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
        public async Task<Estado> ObterEstadoAsync(int Id)
        {
            var EstadInfo = new Estado();
            HttpResponseMessage Res = await Initialize().GetAsync($"api/Estados/{Id}");
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                EstadInfo = JsonConvert.DeserializeObject<Estado>(EmpResponse);
            }
            return EstadInfo;
        }

        public async Task<IEnumerable<Estado>> ObterTodosEstadosAsync()
        {
            IEnumerable<Estado> EstadInfo = new List<Estado>();

            HttpResponseMessage Res = await Initialize().GetAsync("api/Estados");
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                EstadInfo = JsonConvert.DeserializeObject<List<Estado>>(EmpResponse);
            }
            return EstadInfo;
        }
    }
}
