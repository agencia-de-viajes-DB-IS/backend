using System;
using System.Collections.Generic;

namespace TravelAgency.Domain.Entities;

public partial class IndividualReservation
{
    public string AgencyId { get; set; } = null!;

    public string TouristId { get; set; } = null!;

    public DateTime ReservationDate { get; set; }

    public string? ExcursionId { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual Excursion? Excursion { get; set; }

    public virtual Tourist Tourist { get; set; } = null!;
}
