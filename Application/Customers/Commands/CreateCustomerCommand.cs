using Application.Customers.DTO;
using MediatR;

namespace Application.Customers.Commands
{
    public record CreateCustomerCommand(string Name, string Email) : IRequest<CustomerDto>;
}
