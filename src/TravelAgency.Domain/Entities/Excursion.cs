using System;
using System.Collections.Generic;

namespace TravelAgency.Domain.Entities;

public partial class Excursion
{
    public string Id { get; set; } = null!;

    public string? DeparturePlace { get; set; }

    public string? ArrivalPlace { get; set; }

    public DateTime? DepartureDate { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public virtual ICollection<GroupReservation> GroupReservations { get; set; } = new List<GroupReservation>();

    public virtual ICollection<IndividualReservation> IndividualReservations { get; set; } = new List<IndividualReservation>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<Agency> Agencies { get; set; } = new List<Agency>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
