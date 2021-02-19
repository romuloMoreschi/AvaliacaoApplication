using AvaliacaoApi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoApplication.Models
{
    public class Equipamento
    {
        [Required(ErrorMessage = "Campos obrigatórios")]
        [DisplayName("Identificador do Equipamento")]
        public int Id { get; set; }
        public string Nome { get; set; }
        
        [DisplayName("Estado de Origem")]
        public string EstadoOrigem { get; set; }

        [DisplayName("Estado de Destino")]
        public string EstadoDestino { get; set; }

        [DisplayName("Sentido da Via")]
        public SentidoVia SentidoVia { get; set; }

        [DisplayName("Sentido da Leitura")]
        public SentidoLeitura SentidoLeitura { get; set; }
        public bool Situacao { get; set; }
        public int EstadoOrigemId { get; set; }
        public int EstadoDestinoId { get; set; }
    }
}
