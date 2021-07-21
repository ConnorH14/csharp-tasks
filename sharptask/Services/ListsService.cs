using System.Collections.Generic;
using sharptask.Models;
using sharptask.Repositories;

namespace sharptask.Services
{
  public class ListsService
  {
    private readonly ListsRepository _listsRepo;

    public ListsService(ListsRepository listsRepo)
    {
      _listsRepo = listsRepo;
    }

    // public List<List> GetLists()
    // {
    //   return _listsRepo.GetAll();
    // }

    public List<List> GetLists(string creatorId)
    {
      return _listsRepo.GetAll(creatorId);
    }


    public List CreateList(List data)
    {
      var list = _listsRepo.Create(data);
      return list;
    }
  }
}