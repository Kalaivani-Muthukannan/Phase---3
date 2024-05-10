using System;
using MetroCardManagement;
namespace MetroCardMangement;
class Program
{
    public static void Main(string[] args)
    {
        //Operations.AddDefaultData();
        FileHandling.Create();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();

    }
}

