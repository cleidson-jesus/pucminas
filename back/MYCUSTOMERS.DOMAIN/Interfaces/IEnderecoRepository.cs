using System.Collections.Generic;
using MYCUSTOMERS.DOMAIN.Entities;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> RetornarEnderecos(int idCliente);
        public void IncluirEnderecos(IEnumerable<Endereco> enderecos);
        public Endereco IncluirEndereco(Endereco endereco);
        public void AtualizarEndereco(Endereco endereco);
    }
}
