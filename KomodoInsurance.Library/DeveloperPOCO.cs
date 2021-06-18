using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DeveloperPOCO
    {

    }

    public class Developer
    {
        public string DevName { get; set; }

        public string DevID { get; set; }

        public bool Pluralsight { get; set; }

        public Developer() 
        {
            
        }

        public Developer (string devName, string devID, bool pluralsight)
        {
            this.DevName = devName;
            this.DevID = devID;
            this.Pluralsight = pluralsight;
        }
    }
}
