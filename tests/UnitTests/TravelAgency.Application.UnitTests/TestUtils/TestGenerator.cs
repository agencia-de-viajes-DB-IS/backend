using TravelAgency.Domain.Entities;
using TravelAgency.Domain.ValueObjects;
using Bogus;

namespace TravelAgency.Application.UnitTests.TestsUtils;

public class TestGenerator
{
    private const int SEED = 1;
    private readonly Faker<User> _userFaker;
    private readonly Faker<Facility> _facilityFaker;
    private readonly Faker<ExtendedExcursion> _extendedExcursionFaker;
    private readonly Faker<Package> _packageFaker;
    public TestGenerator()
    {
        Randomizer.Seed = new Random(SEED); // Here we're setting up a randomizer seed

        _userFaker = new Faker<User>("en") // By default Locate is set to "en", but we can use others like, "es", "fr", "de", ...
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.Password, f => f.Random.AlphaNumeric(10))
            .RuleFor(u => u.Role, new Role() { Name = "User", Permissions = new List<Domain.Enums.Permissions>() });

        _facilityFaker = new Faker<Facility>()
            .RuleFor(f => f.Id, f => f.Random.Int())
            .RuleFor(f => f.Name, f => f.Lorem.Sentence())
            .RuleFor(f => f.Description, f => f.Lorem.Paragraph(7));

        var agencyId = Guid.NewGuid();
        _extendedExcursionFaker = new Faker<ExtendedExcursion>("es")
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.Location, f => f.Address.FullAddress())
            .RuleFor(e => e.Price, f => f.Random.Decimal(10, 500))
            .RuleFor(e => e.ArrivalDate, f => f.Date.Soon())
            .RuleFor(e => e.DepartureDate, f => f.Date.Soon())
            .RuleFor(e => e.AgencyId, agencyId);

        _packageFaker = new Faker<Package>()
            .RuleFor(p => p.Code, f => Guid.NewGuid())
            .RuleFor(p => p.Price, f => f.Random.Decimal(10, 500))
            .RuleFor(p => p.ArrivalDate, f => f.Date.Soon())
            .RuleFor(p => p.DepartureDate, f => f.Date.Soon())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph(7));
    }
    public User GenerateUser() => _userFaker.Generate();
    public List<Package> GeneratePackages(int amount = 5) => _packageFaker.Generate(amount);
    public List<Facility> GenerateFacilities(int amount = 5) => _facilityFaker.Generate(amount);
    public List<ExtendedExcursion> GenerateExcursions(int amount = 5) => _extendedExcursionFaker.Generate(amount);
}