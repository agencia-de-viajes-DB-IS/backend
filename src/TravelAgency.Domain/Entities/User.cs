namespace TravelAgency.Domain.Entities;

public class User
{
    Guid Id { get; set; }
    string Name { get; set; } = null!;
    string LastName { get; set; } = null!;
    string Email { get; set; } = null!;
    string Role { get; set; } = null!;
}