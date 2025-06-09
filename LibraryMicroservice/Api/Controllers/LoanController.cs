using Application.Commands.Loans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ISender _mediator;

        public LoanController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateLoanCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid loan data.");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
