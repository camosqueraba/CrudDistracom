using CrudData;
using CrudData.core;
using CrudRepository.Interfaces;
using Microsoft.Extensions.Options;
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
    public class CourseRepository : ICourse
    {
        private readonly IOptions<StringConnection> StringConnection;

        public CourseRepository(IOptions<StringConnection> pConnectionStrings)
        {
            StringConnection = pConnectionStrings;
        }

        public void create(Course course)
        {

            string strJsonCourse = JsonConvert.SerializeObject(course, Formatting.Indented);

            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.createCourse", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@jsonCourse", strJsonCourse);
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

        public IEnumerable<Course> getAll()
        {
            List<Course> lstCourse = new();
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.getAllCourse", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstCourse.Add(new Course()
                                {
                                    id = _SqlDataReader.GetInt32(0),
                                    name = _SqlDataReader.GetString(1)
                                    
                                });
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("getAllCourse() Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return lstCourse;
            }
        }

        public Course getById(int id)
        {
            Course objCourse = new();
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.getCourseById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objCourse.id = _SqlDataReader.GetInt32(0);
                                objCourse.name = _SqlDataReader.GetString(1);
                                
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("GetById(int id) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return objCourse;
            }
        }

        public void update(Course course)
        {
            string strCourseJson = JsonConvert.SerializeObject(course);
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.updateCourseById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@jsonCourse", strCourseJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Course course) Exception: ", exception.Message));
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
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.deleteStudentById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Delete(int id) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
            }
        }
    }

}
