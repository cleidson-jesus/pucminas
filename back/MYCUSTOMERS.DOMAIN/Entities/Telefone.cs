
namespace MYCUSTOMERS.DOMAIN.Entities
{
    public class Telefone
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTipo { get; set; }
        public int Ddd { get; set; }
        public int Numero { get; set; }
        public bool EnvioSms { get; set; }
    }
}
