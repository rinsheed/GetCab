

using Moq;
using Rider.Application.Application.RiderDetail;
using Rider.Application.Contract;
using Rider.Application.Dto.Rider;

namespace Rider.RiderDetail;

public class GetRiderDetailsByIdQueryHandlerTests
{
    private readonly Mock<IRiderDbContext> _dbContext;

    public GetRiderDetailsByIdQueryHandlerTests()
    {
        _dbContext = new Mock<IRiderDbContext>();        
    }

    [Fact]
    public async Task GetRiderDetailsById_ShouldThrow_NotFoundException()
    {
        // Arrange
        _dbContext.Setup(x => x.RiderDetails.Add(new Domain.Domain.RiderDetail
        {
            Id = 1,
            Address = "1456, USA",
            Name = "John Doe"
        }));
        var request = new GetRiderDetailsByIdQuery() { Id = 2 };

        var handler = new GetRiderDetailsByIdQueryHandler(_dbContext.Object);

        // Act and assert
        await Assert.ThrowsAsync<InvalidDataException>(() => handler.Handle(request, CancellationToken.None));
        
    }

    [Fact]
    public async Task GetRiderDetailsById_ShouldThrow_UnexpectedException()
    {
        // Arrange
        var request = new GetRiderDetailsByIdQuery() { Id = 1 };

        var handler = new GetRiderDetailsByIdQueryHandler(_dbContext.Object);

        // Act and assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task GetRiderDetailsById_ShouldReturn_ValidUserDetails()
    {
        // Arrange
        const int id = 1;
        const string name = "John Doe";
        const string address = "1456, USA";

        _dbContext.Setup(x => x.RiderDetails.Add(new Domain.Domain.RiderDetail
        {
            Id = id,
            Address = address,
            Name = name
        }));

        var request = new GetRiderDetailsByIdQuery() { Id = id };

        var handler = new GetRiderDetailsByIdQueryHandler(_dbContext.Object);

        // Act 
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(id, response.Id);
        Assert.Equal(address, response.Address);
        Assert.Equal(name, response.Name);

    }
}
