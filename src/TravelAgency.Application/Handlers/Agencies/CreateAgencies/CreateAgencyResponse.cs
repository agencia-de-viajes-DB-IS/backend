using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Agencies.CreateAgencies;

public class CreateAgencyResponse : BaseResponse
{
    public CreateAgencyResponse(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}