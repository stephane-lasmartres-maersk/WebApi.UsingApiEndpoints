using System;
using System.Threading.Tasks;
using WebApi.UsingApiEndpoints.Domains;

namespace WebApi.UsingApiEndpoints.Services
{
    public interface IGetCustomer
    {
        Task<Customer> Get(Guid id);
    }
}
