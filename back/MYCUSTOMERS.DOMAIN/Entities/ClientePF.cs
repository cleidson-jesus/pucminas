using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCUSTOMERS.DOMAIN.Entities
{
    public class ClientePF : Cliente
    {
        public int IdGenero { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdCidadeNascimento { get; set; }
        public string NumeroDocIdentificacao { get; set; }
        public Decimal Renda { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}
