using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UsingApiEndpoints.Domains;

namespace WebApi.UsingApiEndpoints.Services
{
    public class CustomerService : ICreateCustomer, IGetCustomer, IGetAllCustomers
    {
        private readonly Dictionary<Guid, Customer> _allCustomers = new Dictionary<Guid, Customer>();

        public Task Add(Customer customer)
        {
            _allCustomers.Add(customer.Id, customer);
            return Task.CompletedTask;
        }

        public Task<Customer> Get(Guid id) => Task.FromResult(_allCustomers[id]);

        public Task<IEnumerable<Customer>> GetAll() => Task.FromResult(_allCustomers.Select(pair => pair.Value));
    }
}
