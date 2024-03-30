namespace TravelAgency.Domain.Enums;

public enum Permissions
{
    // Writes
    WriteUsers,
    WriteExcursions,
    WritePackages,
    WriteRoles,
    WriteTourists,
    WriteFacilities,
    WritePackageReservation,
    WriteAgencies,
    // Reads
    ReadAgencies,
    ReadHotels,
    ReadHotelDeals,
    ReadPackages,
    ReadExcursions,
    ReadUsers,
    ReadRoles,
    ReadAirlines,
    ReadTourists,
    ReadFacilities,
    ReadPackageReservation    
}