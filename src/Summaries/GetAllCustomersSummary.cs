using api.customer.Contracts.Responses;
using api.customer.Endpoints;
using FastEndpoints;

namespace api.customer.Summaries;

public class GetAllCustomersSummary : Summary<GetAllCustomersEndpoint>
{
    public GetAllCustomersSummary()
    {
        Summary = "Returns all the customers";
        Description = "Returns all the customers";
        Response<GetAllCustomersResponse>(200, "All customers are returned");
    }
}