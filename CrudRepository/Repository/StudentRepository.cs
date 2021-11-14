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
    public class StudentRepository : IStudent
    {
        private readonly IOptions<StringConnection> StringConnection;

        public StudentRepository(IOptions<StringConnection> pConnectionStrings)
        {
            StringConnection = pConnectionStrings;
        }

        void IStudent.create(Student student)
        {


            string strJsonStudent = JsonConvert.SerializeObject(student, Formatting.Indented);

            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.createStudent", _SqlConnection)
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

        IEnumerable<Student> IStudent.getAll()
        {
            List<Student> lstStudent = new();
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.getAllStudent", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstStudent.Add(new Student()
                                {
                                    id = _SqlDataReader.GetInt32(0),
                                    idCard = _SqlDataReader.GetString(1),
                                    name = _SqlDataReader.GetString(2),
                                    lastName = _SqlDataReader.GetString(3),
                                    age = _SqlDataReader.GetInt32(4),
                                    phone = _SqlDataReader.GetString(5),
                                    email = _SqlDataReader.GetString(6),
                                    address = _SqlDataReader.GetString(7)
                                });
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("getAllStudent() Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return lstStudent;
            }
        }

        Student IStudent.getById(int id)
        {
            Student objStudent = new();
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.getStudentById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objStudent.id = _SqlDataReader.GetInt32(0);
                                objStudent.idCard = _SqlDataReader.GetString(1);
                                objStudent.name = _SqlDataReader.GetString(2);
                                objStudent.lastName = _SqlDataReader.GetString(3);
                                objStudent.age = _SqlDataReader.GetInt32(4);
                                objStudent.phone = _SqlDataReader.GetString(5);
                                objStudent.email = _SqlDataReader.GetString(6);
                                objStudent.address = _SqlDataReader.GetString(7);
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
                return objStudent;
            }

        }

        void IStudent.update(Student student)
        {
            string strPersonJson = JsonConvert.SerializeObject(student);
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.updateStudentById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@jsonStudent", strPersonJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Student student) Exception: ", exception.Message));
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
            using (SqlConnection _SqlConnection = new(StringConnection.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.SPDeleteStudentById", _SqlConnection)
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
