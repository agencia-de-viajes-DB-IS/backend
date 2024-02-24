using System;
using System.Collections.Generic;

namespace TravelAgency.Domain.Entities;
public partial class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    // ok
    public int RoleId { get; set; }
    public required Role Role { get; set; }
    
    public ICollection<ReservaPaquete>? ReservaPaquetes {get; set;} // ok
    public ICollection<ReservaExcursión>? ReservaExcursións {get; set;} // ok
    public ICollection<ReservaHospedaje>? ReservaHospedajes {get; set;} // ok
}