using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum Gender
    {
        Male, Female, Transgender
    }
    public enum FoodType
    {
        Veg, NonVeg
    }
    public class PersonalDetail
    {
        public string Name { get; set; }
        public long Phone { get; set; }
        public long AadharNo { get; set; }
        public string Address { get; set; }
        public FoodType FoodType { get; set; }
        public Gender Gender { get; set; }

        public PersonalDetail(string name, long phone, long aadharNo, string address, FoodType foodType, Gender gender)
        {
            Name = name;
            Phone = phone;
            AadharNo = aadharNo;
            Address = address;
            FoodType = foodType;
            Gender = gender;
        }

        public PersonalDetail()
        {

        }
    }
}