using CrudDistracom.Models;
using CrudDistracom.Models.core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrudDistracom.Controllers
{
    public class StudentController : Controller
    {
        private readonly IOptions<ConfigurationManagement> _Service;

        public StudentController(IOptions<ConfigurationManagement> pConfiguration)
        {
            _Service = pConfiguration;
        }
        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task <IEnumerable<StudentModel>> getAll()
        {
            try
            {
                List<StudentModel> lstStudent = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "api/student/getall");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstStudent = JsonConvert.DeserializeObject<List<StudentModel>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstStudent;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }
        [HttpPost]
        public async Task <HttpResponseMessage> Create([FromBody] StudentModel studentModel)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strStudent = JsonConvert.SerializeObject(studentModel);
                    HttpContent _HttpContent = new StringContent(strStudent, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "api/student/create", _HttpContent);
                    return responseMessage;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de enviar los datos al servidor: ", exception));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int pId)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "api/student/delete?id=" + pId);
                    return responseMessage;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de enviar los datos al servidor: ", exception));
            }
        }
    }
}
