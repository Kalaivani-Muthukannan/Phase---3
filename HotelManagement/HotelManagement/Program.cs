using System;
namespace HotelManagement;
class Program
{
    public static void Main(string[] args)
    {
        Operation.AddDefaultData();
        //FileHandling.Create();
        //FileHandling.ReadToCSV();
        Operation.MainMenu();
        //FileHandling.WriteToCSV();
    }
}