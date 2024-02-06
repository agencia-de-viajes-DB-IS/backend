using System;
using System.Collections.Generic;

namespace TravelAgency.Domain.Entities;

public partial class Touristgroup
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<GroupReservation> GroupReservations { get; set; } = new List<GroupReservation>();

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
