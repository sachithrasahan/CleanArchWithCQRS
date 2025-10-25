using Application.Customers.DTO;
using Application.Interfaces;
using MediatR;
using Domain.Entities;

namespace Application.Customers.Commands.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> _repo;

        public CreateCustomerHandler(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Email);
            await _repo.AddAsync(customer);
            return new CustomerDto(customer.Id, customer.Name, customer.Email);
        }
    }
}
