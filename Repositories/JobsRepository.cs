using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_csharp.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Job> GetJobs()
    {
      string sql = "SELECT * FROM jobs;";
      return _db.Query<Job>(sql).ToList();
    }

    internal Job GetJobById(int jobId)
    {
      string sql = "SELECT * FROM jobs WHERE id = @jobId;";
      return _db.QueryFirstOrDefault<Job>(sql, new { jobId });
    }

    internal int CreateJob(Job jobData)
    {
      string sql = @"
      INSERT INTO 
      jobs(position, salary, isFullTime, description)
      VALUES(@Position, @Salary, @IsFullTime, @Description);
      SELECT LAST_INSERT_ID()
      ;";
      return _db.ExecuteScalar<int>(sql, jobData);
    }

    internal Job UpdateJob(Job jobData)
    {
      string sql = @"
      UPDATE jobs SET
      position = @Position,
      salary = @Salary,
      isFullTime = @IsFullTime,
      description = @Description
      WHERE id = @Id LIMIT 1;
      SELECT * FROM jobs WHERE id = @Id
      ;";
      return _db.QueryFirstOrDefault<Job>(sql, jobData);
    }

    internal void RemoveJob(int jobId)
    {
      string sql = "DELETE FROM jobs WHERE id = @jobId;";
      _db.Execute(sql, new { jobId });
    }
  }
}