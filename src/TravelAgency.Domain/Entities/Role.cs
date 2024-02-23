using System.Collections.ObjectModel;

namespace TravelAgency.Domain.Entities;

public class Role
{
    // Main Properties
    public int Id { get; set; }
    public required string Name { get; set; }
    
    // Relational Properties
    public Collection<User>? Users {get; set;}
}