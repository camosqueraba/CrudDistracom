using CrudData;
using CrudRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBLL
{
    public class StudentService
    {
        private readonly IStudent _Repository;

        public StudentService(IStudent istudent)
        {
            _Repository = istudent;
        }

        public void Create(Student student)
        {
            _Repository.create(student);
        }

        public void Delete(int id)
        {
            _Repository.delete(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _Repository.getAll();
        }

        public Student GetById(int id)
        {
            return _Repository.getById(id);
        }

        public void Update(Student student)
        {
            _Repository.update(student);
        }
    }
}
