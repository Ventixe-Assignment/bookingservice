using Presentation.Models;

namespace Presentation.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResult> CreateBookingAsync(BookingRequest request);
    }
}