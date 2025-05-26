using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TodosController(TodoService todoService, IMapper mapper) : BaseApiController
{
    #region Todo CRUD
        /*--------- Get Todos ---------*/
    [HttpGet("List")]
    public async Task<ActionResult<IEnumerable<TodoListDto>>> GetTodoList()
    {
        var todos = await todoService.GetTodoAsync();
        var todoDto = mapper.Map<IEnumerable<TodoListDto>>(todos);

        return Ok(todoDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoItem>> GetTodoById(int id)
    {
        var todo = await todoService.GetTodoByIdAsync(id);
        if (todo == null) return NotFound();

        var todoDto = mapper.Map<TodoListDto>(todo);

        return Ok(todoDto);
    }
    /*--------- Add Todos ---------*/
    [HttpPost("Add")]
    public async Task<ActionResult<TodoCreateDto>> AddTodoAsync(TodoCreateDto todoDto)
    {
        var newTask = mapper.Map<TodoItem>(todoDto);
        await todoService.AddTodoAsync(newTask);

        return Ok(todoDto);
    }
    /*--------- Update Todos ---------*/
    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> UpdateTodoAsync(TodoCreateDto todoDto, int id)
    {
        var todo = await todoService.GetTodoByIdAsync(id);
        if (todo == null) return NotFound();
        mapper.Map(todoDto, todo);

        await todoService.UpdateTodoAsync(todo);
        return Ok(todoDto);
    }
    /*--------- Delete Todos ---------*/
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        await todoService.DeleteTodoAsync(id);
        return Ok();
    }
    #endregion
}
