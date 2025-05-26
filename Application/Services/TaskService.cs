using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class TaskService: ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        return await _repository.CreateAsync(task);
    }

    public async Task<bool> UpdateAsync(int id, TaskItem task)
    {
        return await _repository.UpdateAsync(id, task);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}