using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entities;

public class BookingOwnerEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;


    [ForeignKey(nameof(BookingOwnerAddress))]
    public string? BookingAddressId { get; set; }
    public BookingAddressEntity? BookingOwnerAddress { get; set; }
}
