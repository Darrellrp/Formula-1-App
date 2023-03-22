using Xunit;
using Formula_1_API.Caching;
using Formula_1_API.Datasources;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Moq;
using AutoFixture;
using FluentAssertions;

namespace Formula_1_API.Tests.Repositories;

public class BaseRepositoryTests : BaseRepositoryBase<Models.Circuit>
{
    [Fact]
    public async Task FindById_WhenEntityIsInCache_ReturnsEntityFromCache()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>().Create();

        CachingService.Setup(x => x.FindById<Models.Circuit>(It.IsAny<int>()))
            .ReturnsAsync(entity);

        var repository = GetBaseRepository();

        // Act
        var result = await repository.FindById(1);

        // Assert
        result.Should().Be(entity);
        CachingService.VerifyAll();
    }

    [Fact]
    public async Task FindById_WhenEntityIsNotInCache_ReturnsEntityFromDatasource()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>().Create();

        CachingService.Setup(x => x.FindById<Models.Circuit>(It.IsAny<int>()))
            .ReturnsAsync(null as Models.Circuit);

        DatasourceAdapter.Setup(x => x.FindById(It.IsAny<int>()))
            .ReturnsAsync(entity);

        CachingService.Setup(x => x.Add(entity));

        var repository = GetBaseRepository();

        // Act
        var result = await repository.FindById(1);

        // Assert
        result.Should().Be(entity);
        CachingService.VerifyAll();
        DatasourceAdapter.VerifyAll();
    }

    [Fact]
    public async Task FindById_WhenEntityIsNotInCacheAndInDatasource_ReturnsNull()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>().Create();

        CachingService.Setup(x => x.FindById<Models.Circuit>(It.IsAny<int>()))
            .ReturnsAsync(null as Models.Circuit);

        DatasourceAdapter.Setup(x => x.FindById(It.IsAny<int>()))
            .ReturnsAsync(null as Models.Circuit);

        var repository = GetBaseRepository();

        // Act
        var result = await repository.FindById(1);

        // Assert
        result.Should().BeNull();
        CachingService.VerifyAll();
        DatasourceAdapter.VerifyAll();
    }
}

public class BaseRepositoryBase<TModel> where TModel : class, IEntity
{
    protected readonly Fixture Fixture = new();
    protected readonly Mock<IDatasourceAdapter<TModel>> DatasourceAdapter = new();
    protected readonly Mock<IMultiplexerCachingService> CachingService = new();

    protected BaseRepository<TModel> GetBaseRepository()
    {
        return new BaseRepository<TModel>(DatasourceAdapter.Object, CachingService.Object);
    }
}