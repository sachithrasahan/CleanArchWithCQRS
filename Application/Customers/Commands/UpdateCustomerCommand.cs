using Application.Customers.DTO;
using MediatR;

namespace Application.Customers.Commands
{
    public record UpdateCustomerCommand(Guid Id, string Name, string Email) : IRequest<CustomerDto>;
}
