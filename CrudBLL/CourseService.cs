using CrudData;
using CrudRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBLL
{
    public class CourseService
    {
        private readonly ICourse _Repository;

        public CourseService(ICourse icourse)
        {
            _Repository = icourse;
        }

        public void Create(Course course)
        {
            _Repository.create(course);
        }

        public void Delete(int id)
        {
            _Repository.delete(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _Repository.getAll();
        }

        public Course GetById(int id)
        {
            return _Repository.getById(id);
        }

        public void Update(Course course)
        {
            _Repository.update(course);
        }
    }
}
