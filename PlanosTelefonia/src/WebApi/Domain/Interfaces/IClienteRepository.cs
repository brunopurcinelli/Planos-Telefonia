using WebApi.Domain.Models;

namespace WebApi.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        //Cliente GetByEmail(string email);
    }
}
