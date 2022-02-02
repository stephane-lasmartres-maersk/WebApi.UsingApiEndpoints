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
    public class CreateCustomerEndpoint : EndpointBaseAsync
        .WithRequest<CreateCustomerRequest>
        .WithResult<IActionResult>
    {
        private readonly ICreateCustomer _customerService;

        public CreateCustomerEndpoint(ICreateCustomer customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("api/customers")]
        [SwaggerOperation(Summary = "Create a customer",
            Description = "Create a customer",
            OperationId = "Customers.Create",
            Tags = new[] { "Customers" })]
        public override async Task<IActionResult> HandleAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var newCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };

            await _customerService.Add(newCustomer);

            return Ok(newCustomer);
        }
    }
}
