using Domain.Entities;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public TasksRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tasks>> GetAsync()
        {
            var rs = await _context.Tasks.ToListAsync();
            return rs;
        }

        public async Task CreateAsync(Tasks task)
        {
            var rs = await _context.Tasks.AddAsync(task);
        }
    }
}
