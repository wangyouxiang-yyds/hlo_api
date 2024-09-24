using HLO_API.Dtos;
using HLO_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HLO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly hlo_dbContext _dbContext;
        public JobController(hlo_dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<JobController>
        [HttpGet]
        // 拿取所有職業
        public IEnumerable<JobDto> Get()
        {
            var get_all_job = from job in _dbContext.job
                              select new JobDto
                              {
                                  JobId = job.JobId,
                                  JobName = job.JobName,
                              };

            return get_all_job;
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
