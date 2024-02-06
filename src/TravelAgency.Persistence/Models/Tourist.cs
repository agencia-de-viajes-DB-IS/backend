using System;
using System.Collections.Generic;

namespace TravelAgency.Persistence.Models;

public partial class Tourist
{
    public string Id { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<IndividualReservationHotel> IndividualReservationHotels { get; set; } = new List<IndividualReservationHotel>();

    public virtual ICollection<IndividualReservation> IndividualReservations { get; set; } = new List<IndividualReservation>();

    public virtual ICollection<Agency> Agencies { get; set; } = new List<Agency>();

    public virtual ICollection<Touristgroup> Groups { get; set; } = new List<Touristgroup>();
}
