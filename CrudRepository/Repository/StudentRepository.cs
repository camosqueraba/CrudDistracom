using CrudData;
using CrudRepository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepository.Repository
{
    public class StudentRepository : IStudent
    {
        void IStudent.create(Student student)
        {
            string strJsonStudent = JsonConvert.SerializeObject(student, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.SPCreateStudent", _SqlConnection)
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

        void IStudent.delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Student> IStudent.getAll()
        {
            throw new NotImplementedException();
        }

        Student IStudent.getById(int id)
        {
            throw new NotImplementedException();
        }

        void IStudent.update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
