using api.customer.Contracts.Responses;
using api.customer.Mappings;
using api.customer.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace api.customer.Endpoints;

[HttpGet("customers"), AllowAnonymous]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<GetAllCustomersResponse>
{
    private readonly ICustomerService _customerService;

    public GetAllCustomersEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetAllAsync();
        var customersResponse = customers.ToCustomersResponse();
        await SendOkAsync(customersResponse, cancellationToken);
    }
}