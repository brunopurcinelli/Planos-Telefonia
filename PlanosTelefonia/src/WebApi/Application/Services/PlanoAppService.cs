using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Application.Interfaces;
using WebApi.Application.ViewModels;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.Services
{
    public class PlanoAppService : IPlanoAppService
    {
        private readonly IPlanoRepository _PlanoRepository;

        public PlanoAppService(IPlanoRepository PlanoRepository)
        {
            _PlanoRepository = PlanoRepository;
        }

        public IEnumerable<PlanoViewModel> GetAll()
        {
            var viewModel = new List<PlanoViewModel>();
            var Planos = _PlanoRepository.GetAll().ToList();
            Planos.ForEach(p => {

                var record = new PlanoViewModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Minutos = p.Minutos,
                    FranquiaInternet = p.FranquiaInternet,
                    Tipo = p.Tipo,
                    Valor = p.Valor
                };
                record.Operadora = new OperadoraViewModel()
                {                    
                    Id = p.Operadora.Id,
                    Nome = p.Operadora.Nome
                };                

                viewModel.Add(record); 
            });
            return viewModel;
        }

        public PlanoViewModel GetById(Guid id)
        {
            var Plano = _PlanoRepository.GetById(id);
            return new PlanoViewModel()
            {
                Id = Plano.Id,
                Nome = Plano.Nome
            };
        }

        public void Register(PlanoViewModel PlanoViewModel)
        {
            var Plano = new Plano(
                new Guid(),
                PlanoViewModel.Nome,
                PlanoViewModel.Minutos,
                PlanoViewModel.FranquiaInternet,
                PlanoViewModel.Valor,
                PlanoViewModel.Tipo
            );
            _PlanoRepository.Add(Plano);
            _PlanoRepository.SaveChanges();
        }

        public void Update(PlanoViewModel PlanoViewModel)
        {
            var Plano = new Plano(
                PlanoViewModel.Id,
                PlanoViewModel.Nome,
                PlanoViewModel.Minutos,
                PlanoViewModel.FranquiaInternet,
                PlanoViewModel.Valor,
                PlanoViewModel.Tipo
            );

            var PlanoExist = _PlanoRepository.GetById(PlanoViewModel.Id);

            if (PlanoExist != null && PlanoExist.Id != Plano.Id)
            {
                if (!PlanoExist.Equals(Plano))
                {
                    throw new Exception("O Plano não existe");
                }
            }

            _PlanoRepository.Update(Plano);
            _PlanoRepository.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _PlanoRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PlanoViewModel> GetByType(TipoPlano tipo)
        {
            var viewModel = new List<PlanoViewModel>();
            var Planos = _PlanoRepository.GetAll().Where(w=>w.Tipo == tipo).ToList();
            Planos.ForEach(p => {

                var record = new PlanoViewModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Minutos = p.Minutos,
                    FranquiaInternet = p.FranquiaInternet,
                    Tipo = p.Tipo,
                    Valor = p.Valor
                };
                record.Operadora = new OperadoraViewModel()
                {
                    Id = p.Operadora.Id,
                    Nome = p.Operadora.Nome
                };

                viewModel.Add(record);
            });
            return viewModel;
        }
        public IEnumerable<PlanoViewModel> GetByOperator(Guid idOperadora)
        {
            var viewModel = new List<PlanoViewModel>();
            var Planos = _PlanoRepository.GetAll().Include("Operadora").Where(w => w.Operadora.Id == idOperadora).ToList();
            Planos.ForEach(p => {

                var record = new PlanoViewModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Minutos = p.Minutos,
                    FranquiaInternet = p.FranquiaInternet,
                    Tipo = p.Tipo,
                    Valor = p.Valor
                };
                record.Operadora = new OperadoraViewModel()
                {
                    Id = p.Operadora.Id,
                    Nome = p.Operadora.Nome
                };

                viewModel.Add(record);
            });
            return viewModel;
        }
        public IEnumerable<PlanoViewModel> GetByOperatorName(string nomeOperadora)
        {
            var viewModel = new List<PlanoViewModel>();
            var Planos = _PlanoRepository.GetAll().Include("Operadora").Where(w => w.Operadora.Nome.Contains(nomeOperadora)).ToList();
            Planos.ForEach(p => {

                var record = new PlanoViewModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Minutos = p.Minutos,
                    FranquiaInternet = p.FranquiaInternet,
                    Tipo = p.Tipo,
                    Valor = p.Valor
                };
                record.Operadora = new OperadoraViewModel()
                {
                    Id = p.Operadora.Id,
                    Nome = p.Operadora.Nome
                };

                viewModel.Add(record);
            });
            return viewModel;
        }
    }
}
