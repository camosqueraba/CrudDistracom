using CrudData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepository.Interfaces
{
    public interface ICourse
    {

        IEnumerable<Course> getAll();
        Course getById(int id);

        void create(Course course);
        void update(Course course);

        void delete(int id);

    }
}
