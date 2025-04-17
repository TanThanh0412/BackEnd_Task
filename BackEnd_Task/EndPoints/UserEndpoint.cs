using Application.Dto;
using Application.Services;

namespace BackEnd_Task.EndPoints
{
    public static class UserEndpoint
    {
        public static void MapUserEndPoints(this WebApplication app)
        {
            app.MapGet("/users", async (IUserService userService) =>
            {
                var rs = await userService.GetAsync();
                return Results.Ok(rs);
            });
        }

        public static void MapUserCreateEndPoints(this WebApplication app)
        {
            app.MapPost("/users", async (IUserService userService, UserRequestDto user) =>
            {
                var rs = await userService.CreateAsync(user);
                return Results.Ok(rs);
            });
        }

        public static void MapUserSignInEndPoints(this WebApplication app)
        {
            app.MapPost("/users/signin", async (IUserService userService, UserRequestDto user) =>
            {
                var rs = await userService.SignInAsync(user);
                return Results.Ok(rs);
            });
        }
    }
}
