using API.Repositories;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.AutoMapper;
using API.Services;
using API.Repositories.Todo;
using API.Interfaces;
using API.Entities;


namespace API.Extensions;

public static class ApplicationServiceExtensions
{
   public static IServiceCollection AddApplicationServices(
    this IServiceCollection services,
    IConfiguration config)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("MainConnection"));

        });
        services.AddScoped<ITodoRepository, TodoRepository>();
       services.AddScoped<IRepository<TodoItem>, Repository<TodoItem>>();

       services.AddScoped<IUnitOfWork, UnitOfWork>();

       services.AddScoped<TodoService>();

    
        services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);


        return services; 
    }
}
