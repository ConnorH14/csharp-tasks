using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using sharptask.Models;

namespace sharptask.Repositories
{
  public class ListsRepository
  {
    private readonly IDbConnection _db;
    public ListsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<List> GetAll(string creatorId)
    {
      string sql = @$"
        SELECT l.*, a.* FROM lists l JOIN accounts a ON l.creatorId = a.id WHERE '{creatorId}' = creatorId;
      ";

      return _db.Query<List, Profile, List>(sql, (l,p) =>
      {
        l.Creator = p;
        return l;
      }, splitOn: "id"
      ).ToList();
    }

    public List Create(List data)
    {
      var sql = @"
        INSERT INTO lists (creatorId, listName)
        VALUES(@CreatorId, @ListName);
        SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }
  }
}