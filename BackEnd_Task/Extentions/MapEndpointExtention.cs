using BackEnd_Task.EndPoints;

namespace BackEnd_Task.Extentions
{
    public static class MapEndpointExtention
    {
        public static void MapEndPoints(this WebApplication app)
        {
            //Tasks
            app.MapTasksEndPoints();
            app.MapTasksCreateEndPoints();

            //Users
            app.MapUserEndPoints();
            app.MapUserCreateEndPoints();
        }
    }
}
