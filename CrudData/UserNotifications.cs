using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudData
{
    public class UserNotifications
    {
        public int id { get; set; }
        public int StudentID { get; set; }

        public bool Email { get; set; }

        public bool Sms { get; set; }

        public bool DirectMail { get; set; }

        public bool PhoneCall { get; set; }

    }
}
