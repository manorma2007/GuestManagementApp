using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Application.Queries;
using GuestManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GuestManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController(ISender sender, IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// This end point is used to Create a new reservation. 
        /// </summary>
        /// <param name="reservation">Reservation entity is required.</param>
        /// <returns code = "200">It returns newly crated reservation.</returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddReservationAsync([FromBody] ReservationEntity reservation)
        {
            var result = await sender.Send(new Application.Commands.Reservation.CreateReservationCommand(reservation));
            if (result == null)
                return BadRequest();           
            return Ok(result);
        }

        /// <summary>
        /// This end point is used to get list of all reservation.
        /// </summary>
        /// <returns code = "200">Returns list of all reservation.</returns>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllReservationsAsync()
        {
            var result = await sender.Send(new GetAllReservationsQuery());
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// This end point is used to get a reservation by ID. 
        /// </summary>
        /// <param name="id">Reservation ID required.</param>
        /// <returns code = "200">Returns reservation by ID.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReservationByIdAsync([FromRoute] Guid id)
        {
           var result = await sender.Send(new GetReservationsByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);           
        }

        /// <summary>
        /// This end point is used to update an existing reservation. 
        /// </summary>
        /// <param name="reservation">Reservation entity required.</param>       
        /// <returns code = "200">Returns updated reservation.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateReservationAsync([FromRoute] Guid id, [FromBody] ReservationEntity reservation)
        {
            var result = await sender.Send(new UpdateReservationCommand(id, reservation));
            if (result == null)
                return NotFound();           
            return Ok(result);
        }

        /// <summary>
        /// This end point is used to update status as "CheckedIn" of an existing reservation. 
        /// </summary>
        /// <param name="id">Reservation ID required.</param>       
        /// <returns code = "200">Returns Status Code 200.</returns>
        [HttpPatch("{id}/check-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckInReservationAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new CheckInReservationCommand(id));
            if (!result)
                return BadRequest();
            return Ok();
        }

        /// <summary>
        /// This end point is used to update status as "CheckedOut" of an existing reservation. 
        /// </summary>
        /// <param name="id">Reservation ID required.</param>       
        /// <returns code = "200">Returns Status Code 200.</returns>
        [HttpPatch("{id}/check-out")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChechOutReservationAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new CheckOutReservationCommand(id));
            if (!result)
                return BadRequest();
            return Ok();
        }
        /// <summary>
        /// This end point is used to cancel an existing reservation. 
        /// </summary>
        /// <param name="id">Reservation ID required.</param>       
        /// <returns code = "200">Returns Status Code 200.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CancelReservationAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new CancelReservationCommand(id));
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
