using Domain.Entities;

namespace Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(TaskItem task);
    Task<bool> UpdateAsync(int id, TaskItem task);
    Task<bool> DeleteAsync(int id);
}