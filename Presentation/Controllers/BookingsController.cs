using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> CreateBooking(BookingRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _bookingService.CreateBookingAsync(request);
        return result.Success
            ? Ok()
            : StatusCode(StatusCodes.Status500InternalServerError, "Unable to create booking");
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetBookings()
    {
        var result = await _bookingService.GetAllBookingsAsync();

        return result.Success
            ? Ok(result.Data)
            : StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve bookings");
    }

    [HttpGet("detailed/{id}")]
    public async Task<IActionResult> GetBooking(string id)
    {
        var result = await _bookingService.GetBookingAsync(id);
        if (!result.Success)
            return NotFound(result.Error ?? "Booking not found");

        return Ok(result.Data);
    }
}
