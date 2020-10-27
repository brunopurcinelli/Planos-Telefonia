using System;
using System.Collections.Generic;
using WebApi.Application.ViewModels;

namespace WebApi.Application.Interfaces
{
    public interface IOperadoraAppService : IDisposable
    {
        void Register(OperadoraViewModel customerViewModel);
        IEnumerable<OperadoraViewModel> GetAll();
        OperadoraViewModel GetById(Guid id);
        void Update(OperadoraViewModel customerViewModel);
        void Remove(Guid id);
    }
}
