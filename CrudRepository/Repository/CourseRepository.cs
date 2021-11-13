using CrudData;
using CrudData.core;
using CrudRepository.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepository.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly IOptions<StringConnection> StringConnection;

        public CourseRepository(IOptions<StringConnection> pConnectionStrings)
        {
            StringConnection = pConnectionStrings;
        }

        public void create(Course course)
        {

            string strJsonStudent = JsonConvert.SerializeObject(course, Formatting.Indented);

            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.SPCreateCourse", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@jsonStudent", strJsonStudent);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Create(Student student) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
            }

        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> getAll()
        {
            throw new NotImplementedException();
        }

        public Course getById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
