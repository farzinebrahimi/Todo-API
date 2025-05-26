using System;
using API.Entities;
using API.Interfaces;

namespace API.Services;

public class TodoService(IUnitOfWork unitOfWork)
{
    public async Task<IEnumerable<TodoItem>> GetTodoAsync()
    {
        return await unitOfWork.TodoRepository.GetAllAsync();
    }
    public async Task<TodoItem> GetTodoByIdAsync(int id)
    {
        return await unitOfWork.TodoRepository.GetByIdAsync(id);
    }
    public async Task AddTodoAsync(TodoItem todos)
    {
        await unitOfWork.TodoRepository.AddAsync(todos);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateTodoAsync(TodoItem todos)
    {
        unitOfWork.TodoRepository.Update(todos);
        await unitOfWork.SaveChangesAsync();
    }
    public async Task DeleteTodoAsync(int id)
    {
        var todo = await unitOfWork.TodoRepository.GetByIdAsync(id);
        if (todo != null)
        {
            unitOfWork.TodoRepository.Delete(todo);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
