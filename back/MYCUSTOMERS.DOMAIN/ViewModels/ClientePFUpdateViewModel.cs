using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCUSTOMERS.DOMAIN.ViewModels
{
    public class ClientePFUpdateViewModel : ClienteUpdateViewModel
    {
        public int IdGenero { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdCidadeNascimento { get; set; }
        public string NumeroDocIdentificacao { get; set; }
        public Decimal Renda { get; set; }
    }
}
