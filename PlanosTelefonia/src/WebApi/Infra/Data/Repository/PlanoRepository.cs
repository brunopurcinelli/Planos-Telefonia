using Equinox.Infra.Data.Context;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Infra.Data.Repository
{
    public class PlanoRepository : Repository<Plano>, IPlanoRepository
    {
        public PlanoRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
