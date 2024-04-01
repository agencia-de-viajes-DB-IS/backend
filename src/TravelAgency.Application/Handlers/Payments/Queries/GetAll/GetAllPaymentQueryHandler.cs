using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Payments.Queries.GetAll; 

public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, GetPaymentsResponse[]>
{
    private readonly IUnitOfWork unitOfWork;

    public GetPaymentsQueryHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<GetPaymentsResponse[]> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
    {
        var PaymentsRepo = unitOfWork.GetRepository<PaymentOperation>();
        var response = (await PaymentsRepo.FindAllAsync())
            .Select(Payments => new GetPaymentsResponse(
                    Payments.Id,
                    Payments.Status,
                    Payments.Description,
                    Payments.ExternalPaymentId,
                    Payments.InternalPaymentId, 
                    Payments.ProductsInfoSerializedJson
        ));
        return response.ToArray();
    }
}