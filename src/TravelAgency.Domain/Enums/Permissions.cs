namespace TravelAgency.Domain.Enums;

public enum Permissions
{
    // Writes
    WriteUsers,
    WriteExcursions,
    WritePackages,

    // Reads
    ReadAgencies,
    ReadHotels,
    ReadHotelDeals,
    ReadPackages,
    ReadExcursions,
    ReadUsers,
}