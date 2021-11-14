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
    public class StudentController : Controller
    {
        private readonly StudentService _Service;
        public StudentController(IStudent pIStudent)
        {
            _Service = new(pIStudent);
        }

        [HttpPost]
        [Route("api/student/create")]
        public void Create([FromBody] Student student)
        {
            _Service.Create(student);
        }

        [HttpDelete]
        [Route("api/student/delete")]
        public void Delete(int id)
        {
            _Service.Delete(id);
        }

        [HttpGet]
        [Route("api/student/getall")]
        public IEnumerable<Student> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("api/student/getbyid")]
        public Student GetById(int id)
        {
            return _Service.GetById(id);
        }

        [HttpPut]
        [Route("api/student/update")]
        public void Update([FromBody] Student pStudent)
        {
            _Service.Update(pStudent);
        }

    }
}
