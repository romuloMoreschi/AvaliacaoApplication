using AvaliacaoApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoApplication.Repository.Contract
{
    public interface IEstadosRepository
    {
        Task<Estado> ObterEstadoAsync(int Id);
        Task<IEnumerable<Estado>> ObterTodosEstadosAsync();
    }
}
