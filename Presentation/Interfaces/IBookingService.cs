using Presentation.Models;

namespace Presentation.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResult> CreateBookingAsync(BookingRequest request);
        Task<BookingResult<IEnumerable<Booking>>> GetAllBookingsAsync();
        Task<BookingResult<Booking>> GetBookingAsync(string id);
    }
}