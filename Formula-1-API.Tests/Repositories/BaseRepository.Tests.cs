using Xunit;
using Formula_1_API.Caching;
using Formula_1_API.Datasources;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Moq;
using AutoFixture;
using FluentAssertions;

namespace Formula_1_API.Tests.Repositories;

public class BaseRepositoryTests
{
    private readonly Fixture Fixture = new();
    private readonly Mock<IDatasourceAdapter<Models.Circuit>> DatasourceAdapter = new();
    private readonly Mock<IMultiplexerCachingService> CachingService = new();

    private BaseRepository<Models.Circuit> GetBaseRepository()
    {
        return new BaseRepository<Models.Circuit>(DatasourceAdapter.Object, CachingService.Object);
    }

    [Fact]
    public async Task FindById_WhenEntityIsInCache_ReturnsEntityFromCache()
    {
        // Arrange
        const int entityId = 1;
        var entity = Fixture.Build<Models.Circuit>().Create();

        CachingService.Setup(x => x.FindById<Models.Circuit>(entityId))
            .ReturnsAsync(entity);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.FindById(entityId);

        // Assert
        result.Should().Be(entity);
        CachingService.VerifyAll();
    }

    [Fact]
    public async Task FindById_WhenEntityIsNotInCache_ReturnsEntityFromDatasource()
    {
        // Arrange
        const int entityId = 1;
        var entity = Fixture.Build<Models.Circuit>().Create();

        CachingService.Setup(x => x.FindById<Models.Circuit>(entityId))
            .ReturnsAsync(null as Models.Circuit);
        DatasourceAdapter.Setup(x => x.FindById(entityId))
            .ReturnsAsync(entity);
        CachingService.Setup(x => x.Add(entity));

        var sut = GetBaseRepository();

        // Act
        var result = await sut.FindById(entityId);

        // Assert
        result.Should().Be(entity);
        CachingService.VerifyAll();
        DatasourceAdapter.VerifyAll();
    }

    [Fact]
    public async Task FindById_WhenEntityIsNotInCacheAndInDatasource_ReturnsNull()
    {
        // Arrange
        const int entityId = 1;
        var entity = Fixture.Build<Models.Circuit>().Create();

        CachingService.Setup(x => x.FindById<Models.Circuit>(entityId))
            .ReturnsAsync(null as Models.Circuit);
        DatasourceAdapter.Setup(x => x.FindById(entityId))
            .ReturnsAsync(null as Models.Circuit);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.FindById(entityId);

        // Assert
        result.Should().BeNull();
        CachingService.VerifyAll();
        DatasourceAdapter.VerifyAll();
    }

    [Fact]
    public async Task GetAll_WhenAllEntitiesAreInCache_ReturnsAllEntities()
    {
        // Arrange
        var entities = Fixture.CreateMany<Models.Circuit>();

        CachingService.Setup(x => x.GetAll<Models.Circuit>())
            .ReturnsAsync(entities);
        DatasourceAdapter.Setup(x => x.GetAll())
            .ReturnsAsync(entities);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetAll();

        // Assert
        result.Should().BeEquivalentTo(entities);
        CachingService.VerifyAll();
        DatasourceAdapter.VerifyAll();
    }

    [Fact]
    public async Task GetAll_WhenSomeEntitiesAreInCache_ReturnsAllEntities()
    {
        // Arrange
        var entities = Fixture.CreateMany<Models.Circuit>();

        CachingService.Setup(x => x.GetAll<Models.Circuit>())
            .ReturnsAsync(entities.Take(2));
        DatasourceAdapter.Setup(x => x.GetAll())
            .ReturnsAsync(entities);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetAll();

        // Assert
        result.Should().BeEquivalentTo(entities);
        CachingService.VerifyAll();
        DatasourceAdapter.VerifyAll();
    }

    [Fact]
    public async Task GetAll_WhenSomeOrNoEntitiesAreInCache_LoadDbEntitiesInCache()
    {
        // Arrange
        var entities = Fixture.CreateMany<Models.Circuit>();

        CachingService.Setup(x => x.GetAll<Models.Circuit>())
            .ReturnsAsync(entities.Take(2));
        DatasourceAdapter.Setup(x => x.GetAll())
            .ReturnsAsync(entities);

        CachingService.Setup(x => x.DeleteAll<Models.Circuit>()).Verifiable();
        CachingService.Setup(x => x.AddMany(entities)).Verifiable();

        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetAll();

        // Assert
        result.Should().BeEquivalentTo(entities);
        CachingService.Verify();
        DatasourceAdapter.Verify();
    }
}
