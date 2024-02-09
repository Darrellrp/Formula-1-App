using Xunit;
using Formula_1_API.Caching;
using Formula_1_API.Datasources;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Moq;
using AutoFixture;
using FluentAssertions;
using Formula_1_API.Factories;
using System.Linq.Expressions;

namespace Formula_1_API.Tests.Repositories;

public class BaseRepositoryTests
{
    private readonly Fixture Fixture = new();
    private readonly Mock<IDatasourceAdapter<Models.Circuit>> DatasourceAdapter = new();
    private readonly Mock<IMultiplexerCachingService> CachingService = new();
    private readonly Mock<EntityCollectionLabelFactory> CollectionKeyFactory = new();

    private BaseRepository<Models.Circuit> GetBaseRepository()
    {
        return new BaseRepository<Models.Circuit>(DatasourceAdapter.Object, CachingService.Object, CollectionKeyFactory.Object);
    }

    private void VerifyAllMocks()
    {
        DatasourceAdapter.VerifyAll();
        CachingService.VerifyAll();
        CollectionKeyFactory.VerifyAll();
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
        result!.Record.Should().Be(entity);
        VerifyAllMocks();
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
        result!.Record.Should().Be(entity);
        VerifyAllMocks();
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
        VerifyAllMocks();
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
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task GetAll_WhenSomeEntitiesAreInCache_ReturnsAllEntitiesFromDatasource()
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
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
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

        CachingService.Setup(x => x.DeleteAll<Models.Circuit>());
        CachingService.Setup(x => x.AddMany(entities));

        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetAll();

        // Assert
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task GetPaginated_WhenEntitiesAreInCache_ReturnsEntitiesFromCache()
    {
        // Arrange
        const int page = 1;
        const int limit = 100;

        var entities = Fixture.Build<Models.Circuit>().CreateMany();

        CachingService.Setup(x => x.GetPaginated<Models.Circuit>(page, limit))
            .ReturnsAsync(entities);
        DatasourceAdapter.Setup(x => x.GetPaginated(page, limit))
            .ReturnsAsync(entities);


        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetPaginated(page, limit);

        // Assert
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task GetPaginated_WhenEntitiesAreNotInCache_ReturnsEntitiesFromDatasource()
    {
        // Arrange
        const int page = 1;
        const int limit = 100;

        var entities = Fixture.Build<Models.Circuit>().CreateMany();

        // Result cannot be null
        CachingService.Setup(x => x.GetPaginated<Models.Circuit>(page, limit))
            .ReturnsAsync(null as IEnumerable<Models.Circuit>);
        DatasourceAdapter.Setup(x => x.GetPaginated(page, limit))
            .ReturnsAsync(entities);


        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetPaginated(page, limit);

        // Assert
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task GetPaginated_WhenSomeEntitiesAreInCache_ReturnsEntitiesFromDatasource()
    {
        // Arrange
        const int page = 1;
        const int limit = 100;

        var entities = Fixture.Build<Models.Circuit>().CreateMany(4);

        CachingService.Setup(x => x.GetPaginated<Models.Circuit>(page, limit))
            .ReturnsAsync(entities.Take(2));
        DatasourceAdapter.Setup(x => x.GetPaginated(page, limit))
            .ReturnsAsync(entities);


        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetPaginated(page, limit);

        // Assert
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task GetPaginated_WhenSomeEntitiesAreInCache_LoadDbEntitiesInCache()
    {
        // Arrange
        const int page = 1;
        const int limit = 100;

        var entities = Fixture.Build<Models.Circuit>().CreateMany(4);

        CachingService.Setup(x => x.GetPaginated<Models.Circuit>(page, limit))
            .ReturnsAsync(entities.Take(2));
        DatasourceAdapter.Setup(x => x.GetPaginated(page, limit))
            .ReturnsAsync(entities);

        CachingService.Setup(x => x.DeleteAll<Models.Circuit>());
        CachingService.Setup(x => x.AddMany<Models.Circuit>(entities));

        var sut = GetBaseRepository();

        // Act
        var result = await sut.GetPaginated(page, limit);

        // Assert
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task Add_CreatesANewRecord()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>().Create();

        DatasourceAdapter.Setup(x => x.Add(entity))
            .ReturnsAsync(entity);

        CachingService.Setup(x => x.Add(entity));

        var sut = GetBaseRepository();

        // Act
        var result = await sut.Add(entity);

        // Assert
        result.Should().Be(entity);
        VerifyAllMocks();
    }

    [Fact]
    public async Task Add_WhenNewRecordIsNull_ThrowException()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>().Create();

        // newRecord cannot be null
        DatasourceAdapter.Setup(x => x.Add(entity))
            .ReturnsAsync(null as Models.Circuit);

        var sut = GetBaseRepository();

        // Act
        var action = async () => await sut.Add(entity);

        // Assert
        await action.Should().ThrowAsync<Exception>();
        VerifyAllMocks();
    }

    [Fact]
    public async Task Add_WhenNewRecordIdIsNull_ThrowException()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>()
            .Without(x => x.Id)
            .Create();

        // newRecord cannot be null
        DatasourceAdapter.Setup(x => x.Add(entity))
            .ReturnsAsync(entity);

        var sut = GetBaseRepository();

        // Act
        var action = async () => await sut.Add(entity);

        // Assert
        await action.Should().ThrowAsync<Exception>();
        VerifyAllMocks();
    }

    [Fact]
    public async Task AddMany_CreatesNewEntities()
    {
        // Arrange
        var entities = Fixture.Build<Models.Circuit>()
            .CreateMany();

        DatasourceAdapter.Setup(x => x.AddMany(entities))
            .ReturnsAsync(entities);

        CachingService.Setup(x => x.AddMany(entities));

        var sut = GetBaseRepository();

        // Act
        var result = await sut.AddMany(entities);

        // Assert
        result.Collection.Should().BeEquivalentTo(entities);
        VerifyAllMocks();
    }

    [Fact]
    public async Task AddMany_WhenNewRecordsAreNull_ThrowException()
    {
        // Arrange
        var entities = Fixture.Build<Models.Circuit>()
            .CreateMany();

        // newRecords cannot be null
        DatasourceAdapter.Setup(x => x.AddMany(entities))
            .ReturnsAsync(null as IEnumerable<Models.Circuit>);

        var sut = GetBaseRepository();

        // Act
        var action = async () => await sut.AddMany(entities);

        // Assert
        await action.Should().ThrowAsync<Exception>();
        VerifyAllMocks();
    }

    [Fact]
    public async Task AddMany_WhenListOfNewRecordsIsEmpty_ThrowException()
    {
        // Arrange
        var entities = Fixture.Build<Models.Circuit>()
            .CreateMany();

        // newRecords cannot be null
        DatasourceAdapter.Setup(x => x.AddMany(entities))
            .ReturnsAsync(Array.Empty<Models.Circuit>());

        var sut = GetBaseRepository();

        // Act
        var action = async () => await sut.AddMany(entities);

        // Assert
        await action.Should().ThrowAsync<Exception>();
        VerifyAllMocks();
    }

    [Fact]
    public async Task Update_ModifiesAnExistingRecord()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>()
            .Create();

        // newRecords cannot be null
        DatasourceAdapter.Setup(x => x.Update(entity))
            .ReturnsAsync(entity);

        CachingService.Setup(x => x.Update(entity))
            .ReturnsAsync(entity);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.Update(entity);

        // Assert
        result.Should().Be(entity);
        VerifyAllMocks();
    }

    [Fact]
    public async Task Update_WhenUpdatedRecordIsNull_ThrowException()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>()
            .Create();

        // newRecords cannot be null
        DatasourceAdapter.Setup(x => x.Update(entity))
            .ReturnsAsync(null as Models.Circuit);

        var sut = GetBaseRepository();

        // Act
        var action = async () => await sut.Update(entity);

        // Assert
        await action.Should().ThrowAsync<Exception>();
        VerifyAllMocks();
    }

    [Fact]
    public async Task Update_WhenUpdatedRecordIdIsNull_ThrowException()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>()
            .Without(x => x.Id)
            .Create();

        // newRecords cannot be null
        DatasourceAdapter.Setup(x => x.Update(entity))
            .ReturnsAsync(entity);

        var sut = GetBaseRepository();

        // Act
        var action = async () => await sut.Update(entity);

        // Assert
        await action.Should().ThrowAsync<Exception>();
        VerifyAllMocks();
    }

    [Fact]
    public async Task Where_WhenEntitiesAreInCache_ReturnsEntitiesFromCache()
    {
        // Arrange
        var entities = Fixture.Build<Models.Circuit>()
            .Without(x => x.Id)
            .CreateMany();

        // newRecords cannot be null
        CachingService.Setup(x => x.Where(It.IsAny<Func<Models.Circuit, bool>>()))
            .ReturnsAsync(entities);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.Where(x => x.Id == 1);

        // Assert
        result.Should().NotBeNull();
        result.Collection.Should().NotBeEmpty();

        DatasourceAdapter.Verify(x => x.Where(It.IsAny<Expression<Func<Models.Circuit, bool>>>()), Times.Never());
        VerifyAllMocks();
    }

    [Fact]
    public async Task Where_WhenEntitiesAreNotInCache_ReturnsEntitiesFromDatasource()
    {
        // Arrange
        var entities = Fixture.Build<Models.Circuit>()
            .Without(x => x.Id)
            .CreateMany();

        // newRecords cannot be null
        CachingService.Setup(x => x.Where(It.IsAny<Func<Models.Circuit, bool>>()))
            .ReturnsAsync(Array.Empty<Models.Circuit>());

        DatasourceAdapter.Setup(x => x.Where(It.IsAny<Expression<Func<Models.Circuit, bool>>>()))
            .ReturnsAsync(entities);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.Where(x => x.Id == 1);

        // Assert
        result.Should().NotBeNull();
        result.Collection.Should().NotBeEmpty();

        VerifyAllMocks();
    }

    [Fact]
    public async Task Delete_WhenValidEntityIsPassed_EntityIsDeleted()
    {
        // Arrange
        var entity = Fixture.Build<Models.Circuit>()
            .Without(x => x.Id)
            .Create();

        // newRecords cannot be null
        CachingService.Setup(x => x.Delete(It.IsAny<Models.Circuit>()))
            .ReturnsAsync(entity);

        DatasourceAdapter.Setup(x => x.Delete(It.IsAny<Models.Circuit>()))
            .ReturnsAsync(entity);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.Delete(entity);

        // Assert
        result.Should().NotBeNull();
        VerifyAllMocks();
    }

    [Fact]
    public async Task Count_ReturnsNumberOfEntities()
    {
        // Arrange
        const int count = 10;

        DatasourceAdapter.Setup(x => x.Count())
            .ReturnsAsync(count);

        var sut = GetBaseRepository();

        // Act
        var result = await sut.Count();

        // Assert
        result.Should().Be(count);
        VerifyAllMocks();
    }
}
