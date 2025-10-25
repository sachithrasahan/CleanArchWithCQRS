using Application.Customers.Commands;
using Application.Customers.DTO;
using Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            return await _mediator.Send(new GetAllCustomersQuery());
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CreateCustomerCommand command)
        {
            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(id));
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(Guid id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID in URL does not match ID in body");
            }
            var updated = await _mediator.Send(command);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok(result);
        }
    }
}
