using System;
using API.Entities;

namespace API.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ITodoRepository TodoRepository { get; }
    Task<int> SaveChangesAsync();
}
