using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCUSTOMERS.DOMAIN.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
