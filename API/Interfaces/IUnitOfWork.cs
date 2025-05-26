using System;
using API.Entities;

namespace API.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TodoItem> TodoRepository { get; }
    Task<int> SaveChangesAsync();
}
