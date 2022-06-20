using System;
using System.Timers;
namespace Program;

//For working need create directory allPackages with file "package_list.txt" in C drive

public class Promgram
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Welcome to package Removal Tool Based on c#");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("1. exit");
        Console.WriteLine("2. remove all packages");
        string action = Console.ReadLine();

        if (action == "1")
        {
            OpenFile();
        }
        if (action == "2")
        {
            Environment.Exit(0);
        }
    }

    public static void OpenFile()
    {
        System.Timers.Timer timer = new System.Timers.Timer(200);
        string pathName = "C:/allPackages/package_list.txt";

        if (File.Exists(pathName))
        {

            string AllPackages = String.Format("Get-AppxPackage | Out-File -FilePath {0}", pathName);
            System.Diagnostics.Process.Start("powershell.exe", AllPackages);

            string sPattern = "PackageFullName";

            string RemovePackages;

            foreach (string value in File.ReadAllLines(pathName)) 
            {
                if(value.StartsWith(sPattern))
                {
                    string packageName = value.Split(":")[1];

                    RemovePackages = String.Format("Remove-AppxPackage -Package {0}", packageName);

                    System.Diagnostics.Process.Start("powershell.exe", RemovePackages);

                    timer.Elapsed += OnTimedEvent;

                    void OnTimedEvent(Object source, ElapsedEventArgs e)
                    {
                        System.Diagnostics.Process.Start("powershell.exe", "cls");
                    }

                }
                else {
                    int i = 0;
                }
            }

        }
        else
        {
            Console.WriteLine("No file founded");
        }
    }
}
