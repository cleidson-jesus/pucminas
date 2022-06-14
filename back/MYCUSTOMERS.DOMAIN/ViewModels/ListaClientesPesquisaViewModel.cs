using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCUSTOMERS.DOMAIN.ViewModels
{
    public class ListaClientesPesquisaViewModel
    {
        public decimal CpfCnpj { get; set; }
        public string Nome { get; set; }
        public int Id { get; set; }
        public int IdTipo { get; set; } 
    }
}
