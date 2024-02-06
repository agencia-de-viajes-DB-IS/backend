using System;
using System.Collections.Generic;

namespace TravelAgency.Persistence.Models;

public partial class Agency
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<GroupReservation> GroupReservations { get; set; } = new List<GroupReservation>();

    public virtual ICollection<IndividualReservationHotel> IndividualReservationHotels { get; set; } = new List<IndividualReservationHotel>();

    public virtual ICollection<IndividualReservation> IndividualReservations { get; set; } = new List<IndividualReservation>();

    public virtual ICollection<Excursion> Excursions { get; set; } = new List<Excursion>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
