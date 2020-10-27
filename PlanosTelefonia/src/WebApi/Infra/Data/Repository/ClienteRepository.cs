using Equinox.Infra.Data.Context;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
