using CrudData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepository.Interfaces
{
    public interface IStudent
    {
        IEnumerable<Student> getAll();
        Student getById(int id);

        void create(Student student);
        void update(Student student);

        void delete(int id);


    }
}
