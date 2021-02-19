using System.Collections.Generic;

namespace AvaliacaoApplication.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
    }
}
