using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using sharptask.Models;

namespace sharptask.Repositories
{
  public class TasksRepository
  {
    private readonly IDbConnection _db;
    public TasksRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<ListTask> GetAll(string creatorId)
    {
      string sql = @$"
        SELECT * FROM tasks WHERE '{creatorId}' = creatorId;
      ";

      return _db.Query<ListTask>(sql).ToList();
    }

    public ListTask Create(ListTask data)
    {
      var sql = @"
        INSERT INTO tasks (creatorId, taskName, listId)
        VALUES(@CreatorId, @TaskName, @ListId);
        SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }
  }
}