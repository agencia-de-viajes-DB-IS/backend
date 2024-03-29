namespace TravelAgency.Domain.Enums;

public enum Permissions
{
    // Writes
    WriteUsers,
    WriteExcursions,
    WritePackages,
    WriteRoles, 
    // Reads
    ReadAgencies,
    ReadHotels,
    ReadHotelDeals,
    ReadPackages,
    ReadExcursions,
    ReadUsers,
    ReadRoles,
    WriteAgencies
}