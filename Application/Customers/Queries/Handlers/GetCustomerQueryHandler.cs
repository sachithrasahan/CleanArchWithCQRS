using Application.Customers.DTO;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Queries.Handlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);
            if (customer == null) 
            {
                throw new Exception($"Customer not found: {request.Id}");
            }
            return new CustomerDto(customer.Id, customer.Name, customer.Email);
        }
    }
}
