using System;
using System.Collections.Generic;

namespace TravelAgency.Persistence.Models;

public partial class GroupReservation
{
    public string AgencyId { get; set; } = null!;

    public string GroupId { get; set; } = null!;

    public DateTime ReservationDate { get; set; }

    public string? PackageId { get; set; }

    public string? ExcursionId { get; set; }

    public int? ParticipantsAmount { get; set; }

    public decimal? Price { get; set; }

    public string? AeroCompany { get; set; }

    public DateTime? DepartureDate { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual Excursion? Excursion { get; set; }

    public virtual Touristgroup Group { get; set; } = null!;

    public virtual Package? Package { get; set; }
}
