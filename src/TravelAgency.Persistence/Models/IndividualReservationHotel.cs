using System;
using System.Collections.Generic;

namespace TravelAgency.Persistence.Models;

public partial class IndividualReservationHotel
{
    public string AgencyId { get; set; } = null!;

    public string TouristId { get; set; } = null!;

    public DateTime ReservationDate { get; set; }

    public string HotelId { get; set; } = null!;

    public DateTime? ArrivalDate { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Tourist Tourist { get; set; } = null!;
}
