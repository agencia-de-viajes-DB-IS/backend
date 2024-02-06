using System;
using System.Collections.Generic;

namespace TravelAgency.Domain.Entities;

public partial class HotelDeal
{
    public string DealId { get; set; } = null!;

    public string HotelId { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
