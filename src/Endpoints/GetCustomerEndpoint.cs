using api.customer.Contracts.Requests;
using api.customer.Contracts.Responses;
using api.customer.Mappings;
using api.customer.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace api.customer.Endpoints;

[HttpGet("customers/{id:guid}"), AllowAnonymous]
public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public GetCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetAsync(request.Id);

        if (customer is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, cancellationToken);
    }
}