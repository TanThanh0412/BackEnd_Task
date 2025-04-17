using Application.Dto;
using Domain.Entities;
using Application.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAsync();
        Task<Tasks?> GetByIdAsync(Guid Id);
        Task<bool> CreateAsync(TaskRequestDto request);
        Task<bool> UpdateAsync(TaskRequestDto request);
        Task<bool> DeleteAsync(Guid Id);
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

        public async Task<Tasks?> GetByIdAsync(Guid Id)
        {
            var task = await _tasksRepository.GetByIdAsync(Id);

            return task;
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

        public async Task<bool> UpdateAsync(TaskRequestDto request)
        {
            if (request.Id == null)
                return false;

            var task = await _tasksRepository.GetByIdAsync(request.Id);
            if(task != null)
            {
                task.Title = request.Title;
                task.Description = request.Description;
                task.Status = request.Status;
                task.UserId = request.UserId;
                task.DueDate = request.DueDate;    

                await _tasksRepository.UpdateAsync(task);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            var task = await _tasksRepository.GetByIdAsync(Id);
            if (task == null)
                return false;

            await _tasksRepository.DeleteAsync(task);
            var rsSaveChange = await _unitOfWork.SaveChangesAsync();

            return rsSaveChange;
        }
    }
}
