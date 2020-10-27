using System;
using System.Collections.Generic;
using WebApi.Application.ViewModels;
using WebApi.Domain.Models;

namespace WebApi.Application.Interfaces
{
    public interface IPlanoAppService : IDisposable
    {
        void Register(PlanoViewModel customerViewModel);
        IEnumerable<PlanoViewModel> GetAll();
        PlanoViewModel GetById(Guid id);
        IEnumerable<PlanoViewModel> GetByType(TipoPlano tipo);
        IEnumerable<PlanoViewModel> GetByOperator(Guid idOperadora);
        IEnumerable<PlanoViewModel> GetByOperatorName(string nomeOperadora);

        void Update(PlanoViewModel customerViewModel);
        void Remove(Guid id);
    }
}
