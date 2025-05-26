using System;
using API.Data;
using API.Entities;
using API.Interfaces;

namespace API.Repositories.Todo;

public class TodoRepository(DataContext context) : Repository<TodoItem>(context), ITodoRepository
{
   
}
