using api.customer.Contracts.Requests;
using api.customer.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace api.customer.Endpoints;

[HttpDelete("customers/{id:guid}"), AllowAnonymous]
public class DeleteCustomerEndpoint : Endpoint<DeleteCustomerRequest>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var deleted = await _customerService.DeleteAsync(request.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        await SendNoContentAsync(cancellationToken);
    }
}