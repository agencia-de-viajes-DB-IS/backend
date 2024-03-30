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
    ReadPackageReservation,

    // Updates
    UpdatePackages,
    UpdateFacilities,

    // Deletes
    DeletePackages,
    DeleteTourists,
    DeleteFacilities,
    DeletePackageReservation,
    WriteAgencies
}