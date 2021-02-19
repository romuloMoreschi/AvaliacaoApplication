using AvaliacaoApi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoApplication.Models
{
    public class Equipamento
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Identificador do Equipamento")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Estado de Origem")]
        public string EstadoOrigem { get; set; }

        [DisplayName("Estado de Destino")]
        public string EstadoDestino { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Sentido da Via")]
        public SentidoVia SentidoVia { get; set; }

        [DisplayName("Sentido da Leitura")]
        public SentidoLeitura SentidoLeitura { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Situacao { get; set; }
    }
}
