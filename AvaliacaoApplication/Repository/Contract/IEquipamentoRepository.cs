using AvaliacaoApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoApplication.Repository.Contract
{
    public interface IEquipamentoRepository
    {
        Task<bool> CadastrarAsync(Equipamento equipamento);
        Task<bool> AtualizarAsync(Equipamento equipamento, int Id);
        Task<bool> ExcluirAsync(int Id);
        Task<Equipamento> ObterEquipamentoAsync(int Id);
        Task<ICollection<Equipamento>> ObterTodosEquipamentosAsync();
    }
}
