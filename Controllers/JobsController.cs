using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_csharp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService)
    {
      _jobsService = jobsService;
    }

    [HttpGet]
    public ActionResult<List<Job>> GetJobs()
    {
      try
      {
        List<Job> jobs = _jobsService.GetJobs();
        return Ok(jobs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{jobId}")]
    public ActionResult<Job> GetJobById(int jobId)
    {
      try
      {
        Job job = _jobsService.GetJobById(jobId);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Job> CreateJob([FromBody] Job jobData)
    {
      try
      {
        Job job = _jobsService.CreateJob(jobData);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{jobId}")]
    public ActionResult<Job> UpdateJob(int jobId, [FromBody] Job jobData)
    {
      try
      {
        jobData.Id = jobId;
        Job job = _jobsService.UpdateJob(jobData);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{jobId}")]
    public ActionResult<string> RemoveJob(int jobId)
    {
      try
      {
        Job job = _jobsService.RemoveJob(jobId);
        return Ok($"Deleted {job.Position}");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}