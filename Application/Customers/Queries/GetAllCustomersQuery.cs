using Application.Customers.DTO;
using MediatR;

namespace Application.Customers.Queries
{
    public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;
}
