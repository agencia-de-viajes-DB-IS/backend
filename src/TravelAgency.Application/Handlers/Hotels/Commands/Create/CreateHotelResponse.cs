using TravelAgency.Application.Responses;
namespace TravelAgency.Application.Handlers.Hotels.Commands.Create;

public class HotelResponse : BaseResponse
{
    public Guid Id {get; set;}
    public string? Name {get; set;}
};
