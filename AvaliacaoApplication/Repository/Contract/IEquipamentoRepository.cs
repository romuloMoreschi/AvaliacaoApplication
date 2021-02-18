using AvaliacaoApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoApplication.Repository.Contract
{
    public interface IEquipamentoRepository
    {
        Task<bool> CadastrarAsync(Equipamento equipamento);
        void Atualizar(Equipamento equipamento);
        Task<bool> ExcluirAsync(int Id);
        Task<Equipamento> ObterEquipamentoAsync(int Id);
        Task<ICollection<Equipamento>> ObterTodosEquipamentosAsync();
    }
}
