using learn.core1.Data;
using learn.core1.service;
using learn.infra1.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Icourseservice courserservice;
        public CourseController(Icourseservice courserservice)
        {
            this.courserservice = courserservice;

        }

        [HttpDelete("delete/{id}")] //delete record from database
        public bool detecourse(int id)
        {

            return courserservice.deletecoure(id);
        }
        [HttpGet]//retrevie all data
        public List<course_api>course()
        {
            return courserservice.getallcourse();
        }
        [HttpGet("{id}")] // retrive data by id
        public course_api course(int id)
        {

            return courserservice.getbyid(id);
        }
        [HttpPost]//insert new record in database
        public bool createcourse([FromBody]course_api cc)
        {

            return courserservice.insertcourse(cc);
        }
        [HttpPut] //update
        public bool updatecourse( [FromBody]course_api cc)
        {

            return courserservice.updatecourse(cc);
        }



    }
}
