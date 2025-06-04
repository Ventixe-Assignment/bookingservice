namespace Presentation.Models;

public class BookingRequest
{
    public string EventId { get; set; } = null!;
    public int PackageId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public int TicketQuantity { get; set; } = 1;

}
