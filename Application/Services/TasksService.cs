using Application.Dto;
using Domain.Entities;
using Application.Abstractions;

namespace Application.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAsync();
        Task<bool> CreateAsync(TaskRequestDto request);
    }

    public class TasksService : ITasksService
    {
        public ITasksRepository _tasksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TasksService(ITasksRepository tasksRepository, IUnitOfWork unitOfWork)
        {
            _tasksRepository = tasksRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tasks>> GetAsync()
        {
            var rs = await _tasksRepository.GetAsync();
            return rs;
        }

        public async Task<bool> CreateAsync(TaskRequestDto request)
        {
            var task = new Tasks
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                UserId = request.UserId,
                DueDate = request.DueDate,
                CreatedDate = DateTime.UtcNow,
                CreatedById = request.UserId,
            };
            await _tasksRepository.CreateAsync(task);
            
            var rsSaveChange = await _unitOfWork.SaveChangesAsync();
            
            return rsSaveChange;
        }
    } 
}
