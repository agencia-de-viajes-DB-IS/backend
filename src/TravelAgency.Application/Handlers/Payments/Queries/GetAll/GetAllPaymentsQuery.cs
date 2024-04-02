using MediatR;
namespace TravelAgency.Application.Handlers.Payments.Queries.GetAll; 
public record GetPaymentsQuery : IRequest<GetPaymentsResponse[]>;