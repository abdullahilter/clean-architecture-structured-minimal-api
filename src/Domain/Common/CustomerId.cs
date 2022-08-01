using ValueOf;

namespace api.customer.Domain.Common;

public class CustomerId : ValueOf<Guid, CustomerId>
{
    protected override void Validate()
    {
        if (Guid.Empty == Value)
            throw new ArgumentException("Customer Id cannot be empty", nameof(CustomerId));
    }
}