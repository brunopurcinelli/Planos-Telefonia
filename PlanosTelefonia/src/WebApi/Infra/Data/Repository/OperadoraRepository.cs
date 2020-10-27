using Equinox.Infra.Data.Context;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Infra.Data.Repository
{
    public class OperadoraRepository : Repository<Operadora>, IOperadoraRepository
    {
        public OperadoraRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
