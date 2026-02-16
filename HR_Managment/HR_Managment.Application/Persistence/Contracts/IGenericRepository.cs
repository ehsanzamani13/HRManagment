namespace HR_Managment.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(int id);
    Task<bool> IsExists(int id);
}
