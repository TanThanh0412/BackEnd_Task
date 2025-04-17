using Application.Dto;
using Application.Services;

namespace BackEnd_Task.EndPoints
{
    public static class TasksEndPoint
    {
        public static void MapTasksEndPoints(this WebApplication app)
        {
            app.MapGet("/tasks", async (ITasksService tasksService) =>
            {
                var rs = await tasksService.GetAsync();
                return Results.Ok(rs);
            });
        }

        public static void MapTasksGetByIdEndPoints(this WebApplication app)
        {
            app.MapGet("/tasks/{id}", async (ITasksService tasksService, Guid id) =>
            {
                var rs = await tasksService.GetByIdAsync(id);
                return Results.Ok(rs);
            });
        }

        public static void MapTasksCreateEndPoints(this WebApplication app)
        {
            app.MapPost("/tasks", async (ITasksService tasksService, TaskRequestDto task) =>
            {
                var rs = await tasksService.CreateAsync(task);
                return Results.Ok(rs);
            });
        }

        public static void MapTasksUpdateEndPoints(this WebApplication app)
        {
            app.MapPut("/tasks", async (ITasksService tasksService, TaskRequestDto task) =>
            {
                var rs = await tasksService.UpdateAsync(task);
                return Results.Ok(rs);
            });
        }

        public static void MapTasksDeleteEndPoints(this WebApplication app)
        {
            app.MapDelete("/tasks/{id}", async (ITasksService tasksService, Guid id) =>
            {
                var rs = await tasksService.DeleteAsync(id);
                return Results.Ok(rs);
            });
        }
    }
}
