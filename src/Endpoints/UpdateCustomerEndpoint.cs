using api.customer.Contracts.Requests;
using api.customer.Contracts.Responses;
using api.customer.Mappings;
using api.customer.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace api.customer.Endpoints;

[HttpPut("customers/{id:guid}"), AllowAnonymous]
public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerService.GetAsync(request.Id);

        if (existingCustomer is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var customer = request.ToCustomer();
        await _customerService.UpdateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, cancellationToken);
    }
}