using Application.Customers.DTO;
using MediatR;

namespace Application.Customers.Queries
{
    public record GetCustomerQuery(Guid Id) : IRequest<CustomerDto>;
}
