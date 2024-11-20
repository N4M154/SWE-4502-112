using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWeather
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var facade = new WeatherFacade();

            Console.WriteLine("Select location method: 1. By IP, 2. By City, 3. Exit");
            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1: // By IP (WeatherStack)
                        

                    case 2: // By City (OpenWeatherMap)
                        

                    case 3: // Exit
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
