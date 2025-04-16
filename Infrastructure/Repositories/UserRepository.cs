using Application.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAsync()
        {
            var rs = await _userManager.Users.ToListAsync();
            return rs;
        }

        public async Task<bool> CreateAsync(ApplicationUser user, string password)
        {
            var rs = await _userManager.CreateAsync(user, password);
            return rs.Succeeded;
        }
    }
}
