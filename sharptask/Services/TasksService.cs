using System.Collections.Generic;
using sharptask.Models;
using sharptask.Repositories;

namespace sharptask.Services
{
  public class TasksService
  {
    private readonly TasksRepository _tasksRepo;

    public TasksService(TasksRepository tasksRepo)
    {
      _tasksRepo = tasksRepo;
    }

    public List<ListTask> GetTasks(string creatorId)
    {
      return _tasksRepo.GetAll(creatorId);
    }


    public ListTask CreateTask(ListTask data)
    {
      var task = _tasksRepo.Create(data);
      return task;
    }
  }
}