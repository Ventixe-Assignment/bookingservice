namespace Presentation.Models;

public class Booking
{
    public string Id { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public int PackageId { get; set; }
    public DateTime BookingDate { get; set; }
    public int TicketQuantity { get; set; }
    public BookingOwner? BookingOwner { get; set; }
}
