using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public enum Gender
        {
            Select, Male, Female, Transgender
        }
    public class PersonalDetails
    {
            public string Name { get; set; }
            public string FatherName { get; set; }
            public Gender Gender { get; set; }
            public long Phone { get; set; }
            public string MailID { get; set; }


            public PersonalDetails(string name, string fatherName, Gender gender, long phone, string mailID)
            {
                Name = name;
                FatherName = fatherName;
                Gender = gender;
                Phone = phone;
                MailID = mailID;
            }
            public PersonalDetails()
            {
                
            }
        }
}
