using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDistracom.Models
{
    public class ProfileInterestsModel
    {
        public int id { get; set; }
        public int StudentID { get; set; }
        public bool Entertainment { get; set; }

        public bool Gastronomy { get; set; }
        public bool Fashion { get; set; }
        public bool Travels { get; set; }
        public bool Home { get; set; }
        public bool Technology { get; set; }
        public bool sports { get; set; }

        public bool Music { get; set; }

        public bool HealthAndBeauty { get; set; }

        public bool Vehicles { get; set; }


        public bool Pets { get; set; }


        public bool ArtAndCulture { get; set; }

        public bool Mechanics { get; set; }

        public bool Books { get; set; }

        public bool Photography { get; set; }

    }
}
