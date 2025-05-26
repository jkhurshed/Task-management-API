using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.AsNoTracking().ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> UpdateAsync(int id, TaskItem updatedTask)
    {
        var existing = await _context.Tasks.FindAsync(id);
        if (existing == null) return false;

        existing.Title = updatedTask.Title;
        existing.Description = updatedTask.Description;
        existing.IsComplete = updatedTask.IsComplete;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Tasks.FindAsync(id);
        if (existing == null) return false;

        _context.Tasks.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}