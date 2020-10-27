using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.ViewModels;

namespace WebApi.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        void Register(ClienteViewModel customerViewModel);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel GetById(Guid id);
        void Update(ClienteViewModel customerViewModel);
        void Remove(Guid id);
    }
}
