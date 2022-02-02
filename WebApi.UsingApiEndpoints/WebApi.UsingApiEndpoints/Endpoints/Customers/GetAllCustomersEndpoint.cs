using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.UsingApiEndpoints.Domains;
using WebApi.UsingApiEndpoints.Services;

namespace WebApi.UsingApiEndpoints.Endpoints.Customers
{
    public class GetAllCustomersEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithResult<IEnumerable<Customer>>
    {
        private readonly IGetAllCustomers _customerService;

        public GetAllCustomersEndpoint(IGetAllCustomers customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("api/Customers")]
        [SwaggerOperation(Summary = "Get all customers",
            Description = "Get all customers",
            OperationId = "Customers.GetAll",
            Tags = new[] { "Customers" })]
        public override async Task<IEnumerable<Customer>> HandleAsync(CancellationToken cancellationToken = default)
            => await _customerService.GetAll();
    }
}
