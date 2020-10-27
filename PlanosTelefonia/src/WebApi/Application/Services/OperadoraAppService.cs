using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Application.Interfaces;
using WebApi.Application.ViewModels;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.Services
{
    public class OperadoraAppService : IOperadoraAppService
    {
        private readonly IOperadoraRepository _OperadoraRepository;

        public OperadoraAppService(IOperadoraRepository OperadoraRepository)
        {
            _OperadoraRepository = OperadoraRepository;
        }

        public IEnumerable<OperadoraViewModel> GetAll()
        {
            var viewModel = new List<OperadoraViewModel>();
            var Operadoras = _OperadoraRepository.GetAll().ToList();

            Operadoras.ForEach(f =>
            {
                var record = new OperadoraViewModel() { Id = f.Id, Nome = f.Nome };
                record.Planos = new List<PlanoViewModel>();

                f.Planos.ToList().ForEach(p =>
                {
                    record.Planos.Add(new PlanoViewModel()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Minutos = p.Minutos,
                        FranquiaInternet = p.FranquiaInternet,
                        Tipo = p.Tipo,
                        Valor = p.Valor
                    });
                });

                viewModel.Add(record);
            });
            return viewModel;
        }

        public OperadoraViewModel GetById(Guid id)
        {
            var Operadora = _OperadoraRepository.GetById(id);

            return new OperadoraViewModel()
            {
                Id = Operadora.Id,
                Nome = Operadora.Nome
            };
        }

        public void Register(OperadoraViewModel OperadoraViewModel)
        {
            var Operadora = new Operadora(
                new Guid(),
                OperadoraViewModel.Nome
            );
            _OperadoraRepository.Add(Operadora);
            _OperadoraRepository.SaveChanges();
        }

        public void Update(OperadoraViewModel OperadoraViewModel)
        {
            var Operadora = new Operadora(
                OperadoraViewModel.Id,
                OperadoraViewModel.Nome
            );

            var OperadoraExist = _OperadoraRepository.GetById(OperadoraViewModel.Id);

            if (OperadoraExist != null && OperadoraExist.Id != Operadora.Id)
            {
                if (!OperadoraExist.Equals(Operadora))
                {
                    throw new Exception("O Operadora não existe");
                }
            }

            _OperadoraRepository.Update(Operadora);
            _OperadoraRepository.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _OperadoraRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
