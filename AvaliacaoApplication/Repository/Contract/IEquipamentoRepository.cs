using AvaliacaoApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoApplication.Repository.Contract
{
    public interface IEquipamentoRepository
    {
        void Cadastrar(Equipamento equipamento);
        void Atualizar(Equipamento equipamento);
        void Excluir(int Id);
        Task<Equipamento> ObterEquipamentoAsync(int Id);
        ICollection<Equipamento> ObterTodosEquipamentos();
    }
}
