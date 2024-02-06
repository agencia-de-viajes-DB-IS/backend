using System;
using System.Collections.Generic;

namespace TravelAgency.Persistence.Models;

public partial class Hotel
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Category { get; set; }

    public virtual ICollection<HotelDeal> HotelDeals { get; set; } = new List<HotelDeal>();

    public virtual ICollection<IndividualReservationHotel> IndividualReservationHotels { get; set; } = new List<IndividualReservationHotel>();

    public virtual ICollection<Agency> Agencies { get; set; } = new List<Agency>();

    public virtual ICollection<Excursion> Excursions { get; set; } = new List<Excursion>();
}
