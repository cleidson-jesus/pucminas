using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.ViewModels;
using MYCUSTOMERS.HELPERS.CustomExceptionMiddleware;
using System;

namespace MYCUSTOMERS.DOMAIN.Services
{
    public class ClientePFService : IClientePFService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientePFService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ClientePF Consultar(int idCliente)
        {
            var clientePF = unitOfWork.ClientePFRepository.Consultar(idCliente);

            clientePF.Enderecos = unitOfWork.EnderecoRepository.RetornarEnderecos(clientePF.Id);
            clientePF.Telefones = unitOfWork.TelefoneRepository.RetornarTelefones(clientePF.Id);

            return clientePF;
        }

        public ClientePF IncluirCliente(ClientePF cliente)
        {

            if (unitOfWork.ClienteRepository.ClienteExiste(cliente.CpfCnpj))
                throw new AppException("Cliente já existe!");

            if (cliente.Telefones.Count() == 0)
                throw new AppException("É obrigatório informar ao menos um telefone.");

            if(cliente.Enderecos.Count() == 0)
                throw new AppException("É obrigatório informar ao menos um endereço.");
             
            //Demais regras de negócio

            var idCliente = unitOfWork.ClientePFRepository.InserirCliente(cliente);

            cliente.Enderecos.Select(e => { e.IdCliente = idCliente; return e; }).ToList();

            unitOfWork.EnderecoRepository.IncluirEnderecos(cliente.Enderecos);

            cliente.Telefones.Select(t => { t.IdCliente = idCliente; return t; }).ToList();

            unitOfWork.TelefoneRepository.IncluirTelefones(cliente.Telefones);

            //Envio para fila para propagação para demais sistemas

            return Consultar(idCliente);
        }

        public void AtualizarCliente(ClientePFUpdateViewModel cliente)
        {
            //Regras de negócio para atualização

            unitOfWork.ClientePFRepository.AtualizarCliente(cliente);

            //Envio para fila para propagação para demais sistemas
        }

    }
}
