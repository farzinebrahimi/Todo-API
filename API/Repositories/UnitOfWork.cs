using API.Data;
using API.Entities;
using API.Interfaces;
using API.Repositories.Todo;

namespace API.Repositories;

public class UnitOfWork(DataContext context) : IUnitOfWork
{
     private readonly DataContext _context = context;
    private ITodoRepository _todoRepository;

    public ITodoRepository TodoRepository => _todoRepository ??= new TodoRepository(_context);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}

