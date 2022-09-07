using api.customer.Contracts.Requests;
using api.customer.Contracts.Responses;
using api.customer.Mappings;
using api.customer.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace api.customer.Endpoints;

[HttpPost("customers"), AllowAnonymous]
public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();
        await _customerService.CreateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendCreatedAtAsync<CreateCustomerEndpoint>(
            routeValues: new { Id = customer.Id.Value },
            responseBody: customerResponse,
            generateAbsoluteUrl: true,
            cancellation: cancellationToken);
    }
}