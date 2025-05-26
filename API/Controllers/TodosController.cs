using System;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TodosController(DataContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodoList()
    {
        var todos = await context.Todo.ToListAsync();

        return todos;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoModel>> GetTodo(int id)
    {
        var todo = await context.Todo.FindAsync(id);

        if (todo == null) return NotFound();

        return todo;
    }
}
