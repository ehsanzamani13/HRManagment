using HR_Managment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HR_Managment.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly LeaveManagmentDbContext _context;

    public GenericRepository(LeaveManagmentDbContext context)
    {
        this._context = context;
    }
    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task Delete(int id)
    {
        T? entity = await Get(id);
        if (entity != null)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<T?> Get(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<bool> IsExists(int id)
    {
        return await Get(id) != null;
    }
    public async Task<T> Update(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}