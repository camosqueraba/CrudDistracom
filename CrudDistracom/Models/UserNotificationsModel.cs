using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDistracom.Models
{
    public class UserNotificationsModel
    {
        public int id { get; set; }
        public int StudentID { get; set; }

        public bool Email { get; set; }

        public bool Sms  { get; set; }
        
        public bool DirectMail{ get; set; }
        
        public bool PhoneCall { get; set; }
        
    }
}
