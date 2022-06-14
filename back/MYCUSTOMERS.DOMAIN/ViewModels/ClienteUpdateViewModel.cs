using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCUSTOMERS.DOMAIN.ViewModels
{
    public class ClienteUpdateViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipo { get; set; }
        public DateTime DataFichaCadastral { get; set; }
        public int Idrating { get; set; }
        public bool ExposicaoMidia { get; set; }
        public string Email { get; set; }
        public bool PessoaPep { get; set; }
    }
}
