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
  public class ListsController : ControllerBase
  {
    private readonly ListsService _ls;

    public ListsController(ListsService ls)
    {
      _ls = ls;
    }

    // [Authorize]
    // [HttpGet]
    // public ActionResult<List<List>> Get()
    // {
    //   try
    //   {
    //     List<List> lists = _ls.GetLists();
    //     return Ok(lists);
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<List>>> GetLists()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<List> lists = _ls.GetLists(userInfo.Id);
        return Ok(lists);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<List>> Create([FromBody] List listData)
    {
      try{
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        listData.CreatorId = userInfo.Id;

        var l = _ls.CreateList(listData);
        return Created("api/lists/" + l.Id, l);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}