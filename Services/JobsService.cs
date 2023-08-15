using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_csharp.Services
{
  public class JobsService
  {
    private readonly JobsRepository _jobsRepository;

    public JobsService(JobsRepository jobsRepository)
    {
      _jobsRepository = jobsRepository;
    }

    internal List<Job> GetJobs()
    {
      return _jobsRepository.GetJobs();
    }

    internal Job GetJobById(int jobId)
    {
      Job job = _jobsRepository.GetJobById(jobId);
      return job ?? throw new Exception($"[NO JOB MATCHES THE ID {jobId}]");
    }

    internal Job CreateJob(Job jobData)
    {
      int jobId = _jobsRepository.CreateJob(jobData);
      return GetJobById(jobId);
    }

    internal Job UpdateJob(Job jobData)
    {
      Job originalJob = GetJobById(jobData.Id);
      originalJob.Position = jobData.Position ?? originalJob.Position;
      originalJob.Salary = jobData.Salary ?? originalJob.Salary;
      originalJob.IsFullTime = jobData.IsFullTime ?? originalJob.IsFullTime;
      originalJob.Description = jobData.Description ?? originalJob.Description;
      return _jobsRepository.UpdateJob(originalJob);
    }

    internal Job RemoveJob(int jobId)
    {
      Job job = GetJobById(jobId);
      _jobsRepository.RemoveJob(jobId);
      return job;
    }
  }
}