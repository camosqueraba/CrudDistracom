using CrudData;
using CrudRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBLL
{
    class StudentService
    {
        private readonly IStudent _Repository;

        public StudentService(IStudent istudent)
        {
            _Repository = istudent;
        }

        public void Create(Student student)
        {
            _Repository.create(pPerson);
        }

        public void Delete(int pId)
        {
            _Repository.Delete(pId);
        }

        public IEnumerable<Person> GetAll()
        {
            return _Repository.GetAll();
        }

        public Person GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public void Update(Person pPerson)
        {
            _Repository.Update(pPerson);
        }
    }
}
