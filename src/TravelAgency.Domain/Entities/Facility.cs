using System;
using System.Collections.Generic;

namespace TravelAgency.Domain.Entities;

public partial class Facility
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
