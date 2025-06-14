﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entities;

public class BookingEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int PackageId { get; set; }
    public string EventId { get; set; } = null!;
    public int TicketQuantity { get; set; }
    public DateTime BookingDate { get; set; }


    [ForeignKey(nameof(BookingOwner))]
    public string? BookingOwnerId { get; set; }
    public BookingOwnerEntity? BookingOwner { get; set; }

}
