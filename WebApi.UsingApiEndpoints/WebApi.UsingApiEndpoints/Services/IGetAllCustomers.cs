using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.UsingApiEndpoints.Domains;

namespace WebApi.UsingApiEndpoints.Services
{
    public interface IGetAllCustomers
    {
        Task<IEnumerable<Customer>> GetAll();
    }
}
