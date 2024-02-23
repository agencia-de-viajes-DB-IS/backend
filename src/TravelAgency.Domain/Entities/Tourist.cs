namespace TravelAgency.Domain.Entities;

public class Tourist
{
    public Guid Id {get; set;}
    public required string  FirstName {get; set;}
    public required string LastName {get; set;}
    public required string Nationality {get; set;}
}