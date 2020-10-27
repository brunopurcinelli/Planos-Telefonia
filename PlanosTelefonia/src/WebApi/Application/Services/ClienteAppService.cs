using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Interfaces;
using WebApi.Application.ViewModels;
using WebApi.Domain.Core.Bus;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMediatorHandler Bus;

        public ClienteAppService(IClienteRepository ClienteRepository,
                                 IMediatorHandler bus)
        {
            _ClienteRepository = ClienteRepository;
            Bus = bus;
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            var viewModel = new List<ClienteViewModel>();
            var clientes = _ClienteRepository.GetAll().ToList();
            clientes.ForEach(f => { viewModel.Add(new ClienteViewModel() { Id = f.Id, Nome = f.Nome, DDD = f.DDD, Numero = f.Numero }); });
            return viewModel;
        }

        public ClienteViewModel GetById(Guid id)
        {
            var cliente = _ClienteRepository.GetById(id);
            return new ClienteViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                DDD = cliente.DDD,
                Numero = cliente.Numero
            };
        }

        public void Register(ClienteViewModel ClienteViewModel)
        {
            var cliente = new Cliente(
                new Guid(),
                ClienteViewModel.Nome,
                ClienteViewModel.DDD,
                ClienteViewModel.Numero
            );
            _ClienteRepository.Add(cliente);
            _ClienteRepository.SaveChanges();
            
        }

        public void Update(ClienteViewModel ClienteViewModel)
        {
            var cliente = new Cliente(
                ClienteViewModel.Id,
                ClienteViewModel.Nome,
                ClienteViewModel.DDD,
                ClienteViewModel.Numero
            );

            var clienteExist = _ClienteRepository.GetById(ClienteViewModel.Id);

            if (clienteExist != null && clienteExist.Id != cliente.Id)
            {
                if (!clienteExist.Equals(cliente))
                {
                    throw new Exception("O cliente não existe");
                }
            }

            _ClienteRepository.Update(cliente);
            _ClienteRepository.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _ClienteRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
