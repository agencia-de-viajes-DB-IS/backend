using TravelAgency.Domain.Entities;
using TravelAgency.Domain.ValueObjects;

namespace TravelAgency.Application.UnitTests.TestsUtils;

public static class TestGenerator
{
    public static User GenerateUser() => new()
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "doe@gmail.com",
        Password = "doePass",
        Role = new Role()
        {
            Name = "user",
            Permissions = new List<Domain.Enums.Permissions>()
        }
    };
}