using api.customer.Contracts.Responses;
using api.customer.Endpoints;
using FastEndpoints;

namespace api.customer.Summaries;

public class CreateCustomerSummary : Summary<CreateCustomerEndpoint>
{
    public CreateCustomerSummary()
    {
        Summary = "Creates a new customer";
        Description = "Creates a new customer";
        Response<CustomerResponse>(201, "Customer was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}