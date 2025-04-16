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

        public static void MapTasksCreateEndPoints(this WebApplication app)
        {
            app.MapPost("/tasks", async (ITasksService tasksService, TaskRequestDto task) =>
            {
                var rs = await tasksService.CreateAsync(task);
                return Results.Ok(rs);
            });
        }
    }
}
