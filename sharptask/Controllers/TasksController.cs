using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sharptask.Models;
using sharptask.Services;

namespace sharptask.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TasksController : ControllerBase
  {
    private readonly TasksService _ts;

    public TasksController(TasksService ts)
    {
      _ts = ts;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<ListTask>>> GetTasks()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<ListTask> Tasks = _ts.GetTasks(userInfo.Id);
        return Ok(Tasks);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ListTask>> Create([FromBody] ListTask taskData)
    {
      try{
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        taskData.CreatorId = userInfo.Id;

        var t = _ts.CreateTask(taskData);
        return Created("api/tasks/" + t.Id, t);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}