using System;
using System.Collections.Generic;

namespace TravelAgency.Persistence.Models;

public partial class Package
{
    public string PackageId { get; set; } = null!;

    public string? ExcursionId { get; set; }

    public string? PackageCode { get; set; }

    public string? Name { get; set; }

    public int? Duration { get; set; }

    public string? Description { get; set; }

    public virtual Excursion? Excursion { get; set; }

    public virtual ICollection<GroupReservation> GroupReservations { get; set; } = new List<GroupReservation>();

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
