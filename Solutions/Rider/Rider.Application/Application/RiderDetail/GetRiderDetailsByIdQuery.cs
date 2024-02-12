using MediatR;
using Microsoft.EntityFrameworkCore;
using Rider.Application.Contract;
using Rider.Application.Dto.Rider;

namespace Rider.Application.Application.RiderDetail;

public class GetRiderDetailsByIdQuery : IRequest<RiderResponseDto>
{
    public int Id { get; set; }
}

public class GetRiderDetailsByIdQueryHandler : IRequestHandler<GetRiderDetailsByIdQuery, RiderResponseDto>
{
    private readonly IRiderDbContext _dbContext;

    public GetRiderDetailsByIdQueryHandler(IRiderDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<RiderResponseDto> Handle(GetRiderDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var riderDetails = await _dbContext.RiderDetails.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (riderDetails == null)
            {
                throw new InvalidDataException("Rider Id not found");
            }

            return new RiderResponseDto()
            {
                Id = riderDetails.Id,
                Name = riderDetails.Name,
                Address = riderDetails.Address
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occured", ex);
        }
    }
}
