using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.UsingApiEndpoints.Domains;
using WebApi.UsingApiEndpoints.Services;

namespace WebApi.UsingApiEndpoints.Endpoints.Customers
{
    public class GetCustomerEndpoint : EndpointBaseAsync
        .WithRequest<Guid>
        .WithResult<Customer>
    {
        private readonly IGetCustomer _customerService;

        public GetCustomerEndpoint(IGetCustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("api/customers/{id}")]
        [SwaggerOperation(Summary = "Get a single customer",
            Description = "Get a single customer",
            OperationId = "Customers.Get",
            Tags = new[] { "Customers" })]
        public override async Task<Customer> HandleAsync(Guid id, CancellationToken cancellationToken = default)
            => await _customerService.Get(id);
    }
}
