using api.customer.Endpoints;
using FastEndpoints;

namespace api.customer.Summaries;

public class DeleteCustomerSummary : Summary<DeleteCustomerEndpoint>
{
    public DeleteCustomerSummary()
    {
        Summary = "Deleted a customer";
        Description = "Deleted a customer";
        Response(204, "The customer was deleted successfully");
        Response(404, "The customer was not found");
    }
}