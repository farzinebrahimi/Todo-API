using API.Data;
using API.Entities;
using API.Interfaces;

namespace API.Reoisitories;

public class UnitOfWork(DataContext context) : IUnitOfWork
{
    private readonly DataContext _context = context;
    private Repository<TodoItem> _todoRePository;
    public IRepository<TodoItem> TodoRepository => _todoRePository ??= new Repository<TodoItem>(_context);
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}
