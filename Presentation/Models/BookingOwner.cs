namespace Presentation.Models;

public class BookingOwner
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public BookingAddress? BookingAddress { get; set; }

}
