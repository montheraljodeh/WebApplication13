using learn.core1.DTO;
using learn.core1.service;
using learn.infra1.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class emp_apiController : ControllerBase
    {
        private readonly Iemp_service service;
        public emp_apiController(Iemp_service service)
        {
            this.service = service;
        }

        [HttpGet]

        public List<emp_dto> get()
        {
            return service.get();
        }

        [HttpPost("getfnamebetweendate")]
        public List<emp_dto> getfnamedate([FromBody]emp_Date emp)
        {
            return service.getfnamedate(emp);
        }
        [HttpPost("getfnamebetweendate1")]

        public List<emp_dto> getfnamelnamedate([FromBody]  emp_Date emp)
        {
            return service.getfnamelnamedate(emp);
        }
    }

}
