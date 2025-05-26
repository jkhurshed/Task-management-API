using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController: ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public TasksController(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    // GET: /api/tasks
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllAsync();
        var result = _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
        return Ok(result);
    }

    // GET: /api/tasks/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task == null) return NotFound();
        return Ok(_mapper.Map<TaskItemDto>(task));
    }

    // POST: /api/tasks
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskDto dto)
    {
        var task = _mapper.Map<TaskItem>(dto);
        var created = await _taskService.CreateAsync(task);
        var result = _mapper.Map<TaskItemDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // PUT: /api/tasks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto dto)
    {
        var task = _mapper.Map<TaskItem>(dto);
        var updated = await _taskService.UpdateAsync(id, task);
        return updated ? NoContent() : NotFound();
    }

    // DELETE: /api/tasks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _taskService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}