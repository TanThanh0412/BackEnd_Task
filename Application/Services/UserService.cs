using Application.Abstractions;
using Application.Dto;
using Domain.Entities;

namespace Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAsync();
        Task<bool> CreateAsync(UserRequestDto request);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAsync()
        {
            var rs = await _userRepository.GetAsync();
            return rs;
        }
        public async Task<bool> CreateAsync(UserRequestDto request)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = request.Password,
            };
            var rs = await _userRepository.CreateAsync(applicationUser, request.Password);
            
            return rs;
        }
    }
}
