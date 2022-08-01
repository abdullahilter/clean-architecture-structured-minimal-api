using api.customer.Contracts.Responses;
using api.customer.Endpoints;
using FastEndpoints;

namespace api.customer.Summaries;

public class UpdateCustomerSummary : Summary<UpdateCustomerEndpoint>
{
    public UpdateCustomerSummary()
    {
        Summary = "Updates an existing customer";
        Description = "Updates an existing customer";
        Response<CustomerResponse>(201, "Customer was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}