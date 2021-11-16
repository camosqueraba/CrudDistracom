using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudData
{
    public class Student
    {
        public int id { get; set; }
        public string idCard { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public string courses { get; set; }
        public ProfileInterests profileInterests { get; set; }

        public UserNotifications userNotifications { get; set; }

    }
}
