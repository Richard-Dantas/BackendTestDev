using BackendTest.Domain.Core.Enumerables;

namespace BackendTest.Domain.Core.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public StatusTarefa Status { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<ArquivoAnexado>? ArquivosAnexados { get; set; }
    }
}
