using Application.Customers.DTO;
using Application.Customers.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Queries.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly IRepository<Customer> _repo;

        public GetAllCustomersHandler(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var list = await _repo.ListAsync();
            return list.Select(x => new CustomerDto(x.Id, x.Name, x.Email));
        }
    }
}
