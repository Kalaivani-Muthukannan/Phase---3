using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        public string Name { get; set; }
        public long Phone { get; set; }

        public PersonalDetails(string name, long phone)
        {
            Name = name;
            Phone = phone;
        }

        public PersonalDetails()
        {
            
        }
    }
}