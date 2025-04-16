using Domain.Entities;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAsync();

        Task<bool> CreateAsync(ApplicationUser user, string password);
    }
}
