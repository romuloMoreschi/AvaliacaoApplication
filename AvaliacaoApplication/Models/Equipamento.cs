using AvaliacaoApi.Enums;
using System.ComponentModel;

namespace AvaliacaoApplication.Models
{
    public class Equipamento
    {   
        [DisplayName("Identificador do Equipamento")]
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("UF de Origem")]
        public string EstadoOrigem { get; set; }
        [DisplayName("UF de Destino")]
        public string EstadoDestino { get; set; }
        [DisplayName("Sentido da Via")]
        public SentidoVia SentidoVia { get; set; }
        [DisplayName("Sentido da Leitura")]
        public SentidoLeitura SentidoLeitura { get; set; }
        public bool Situacao { get; set; }
    }
}
