using CrudDistracom.Models;
using CrudDistracom.Models.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrudDistracom.Controllers
{
    public class CourseController : Controller
    {
        private readonly IOptions<ConfigurationManagement> _Service;

        public CourseController(IOptions<ConfigurationManagement> pConfiguration)
        {
            _Service = pConfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IEnumerable<CourseModel>> getAll()
        {
            try
            {
                List<CourseModel> lstCourse = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "api/course/getall");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstCourse = JsonConvert.DeserializeObject<List<CourseModel>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstCourse;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }
    }

    
}
