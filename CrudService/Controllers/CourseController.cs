using CrudBLL;
using CrudData;
using CrudRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudService.Controllers
{
   
    [ApiController]
    public class CourseController : Controller
    {
        private readonly CourseService _Service;
        public CourseController(ICourse pICourse)
        {
            _Service = new(pICourse);
        }

        [HttpPost]
        [Route("api/course/create")]
        public void Create([FromBody] Course course)
        {
            _Service.Create(course);
        }

        [HttpDelete]
        [Route("api/course/delete")]
        public void Delete(int id)
        {
            _Service.Delete(id);
        }

        [HttpGet]
        [Route("api/course/getall")]
        public IEnumerable<Course> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("api/course/getbyid")]
        public Course GetById(int id)
        {
            return _Service.GetById(id);
        }

        [HttpPut]
        [Route("api/course/update")]
        public void Update([FromBody] Course pCourse)
        {
            _Service.Update(pCourse);
        }
    }
}
