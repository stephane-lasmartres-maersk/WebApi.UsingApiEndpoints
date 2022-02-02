using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.UsingApiEndpoints.Domains;

namespace WebApi.UsingApiEndpoints.Services
{
    public interface ICreateCustomer
    {
        Task Add(Customer customer);
    }
}