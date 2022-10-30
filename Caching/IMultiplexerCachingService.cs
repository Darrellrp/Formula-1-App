using Formula_1_App.Models;

namespace Formula_1_App.Caching
{
    public interface IMultiplexerCachingService
    {
        Task<T?> FindById<T>(int id);
        Task<IEnumerable<T>> Where<T>(Func<T, bool> expression) where T : class, IEntity;
        Task<IEnumerable<T>> GetAll<T>();
        Task<IEnumerable<T>> GetPaginated<T>(int page, int limit = 100) where T : class, IEntity;
        Task Add<T>(T entity) where T : class, IEntity;
        Task AddMany<T>(IEnumerable<T> entities) where T : class, IEntity;
        Task<T> Update<T>(T entity) where T : class, IEntity;
        Task<T> Delete<T>(T entity) where T : class, IEntity;

    }
}
