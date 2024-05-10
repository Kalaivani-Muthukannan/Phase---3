using System;
namespace CafeteriaCardManagement;
class Program
{
    public static void Main(string[] args)
    {
       Operations.AddDefaultDatas();
       FileHandling.Create();
       FileHandling.ReadFromCSV();
       Operations.MainMenu();
       FileHandling.WriteToCSV();
    }
}
