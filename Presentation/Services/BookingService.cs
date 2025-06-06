using Presentation.Data.Entities;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services;

/* CI/CD connected */
public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    public async Task<BookingResult> CreateBookingAsync(BookingRequest request)
    {
        var bookingEntity = new BookingEntity
        {
            EventId = request.EventId,
            PackageId = request.PackageId,
            BookingDate = DateTime.Now,
            TicketQuantity = request.TicketQuantity,
            BookingOwner = new BookingOwnerEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                BookingOwnerAddress = new BookingAddressEntity
                {
                    City = request.City,
                    Street = request.Street,
                    PostalCode = request.PostalCode
                }
            }
        };

        var result = await _bookingRepository.AddAsync(bookingEntity);
        return result.Success
            ? new BookingResult { Success = true, Id = bookingEntity.Id}
            : new BookingResult { Success = false, Error = "Failed to create booking" };
    }

    public async Task<BookingResult<IEnumerable<Booking>>> GetAllBookingsAsync()
    {
        var result = await _bookingRepository.GetAllAsync();
        var bookings = result.Data?.Select(e => new Booking
        {
            Id = e.Id,
            EventId = e.EventId,
            TicketQuantity = e.TicketQuantity,
            BookingDate = e.BookingDate
        });
        
        return new BookingResult<IEnumerable<Booking>> { Success = result.Success, Data = bookings };
    }

    public async Task<BookingResult<Booking>> GetBookingAsync(string id)
    {
        var result = await _bookingRepository.GetAsync(x => id == x.Id);

        if (!result.Success || result.Data == null)
            return new BookingResult<Booking> { Success = false, Error = "Booking not found, or booking is null" };

        var booking = new Booking
        {
            Id = result.Data.Id,
            EventId = result.Data.EventId,
            PackageId = result.Data.PackageId,
            TicketQuantity = result.Data.TicketQuantity,
            BookingDate = result.Data.BookingDate,
            BookingOwner = new BookingOwner
            {
                FirstName = result.Data.BookingOwner!.FirstName,
                LastName = result.Data.BookingOwner!.LastName,
                Email = result.Data.BookingOwner!.Email,
                BookingAddress = new BookingAddress
                {
                    City = result.Data.BookingOwner.BookingOwnerAddress!.City,
                    Street = result.Data.BookingOwner.BookingOwnerAddress!.Street,
                    PostalCode = result.Data.BookingOwner.BookingOwnerAddress!.PostalCode
                }
            }
        };

        return new BookingResult<Booking> { Success = true, Data = booking };
    } 
}
