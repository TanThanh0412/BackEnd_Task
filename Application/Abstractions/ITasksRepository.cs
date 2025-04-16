using Domain.Entities;

namespace Application.Abstractions
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAsync();

        Task CreateAsync(Tasks task);
    }
}
