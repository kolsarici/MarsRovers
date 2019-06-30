using System;
using MarsRovers.Business.Abstract;
using MarsRovers.Business.Concrete.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRovers.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPlateauService, PlateauManager>()
                .AddScoped<IRoverService, RoverManager>()
                .BuildServiceProvider();

            var plateauService = serviceProvider.GetService<IPlateauService>();
            var roverService = serviceProvider.GetService<IRoverService>();

            while (true)
            {
                Console.WriteLine("Enter the upper-right coordinates of the plateau:");
                var plateauInput = Console.ReadLine();
                if (plateauInput == "-1")
                {
                    break;
                }
                var plateauResponse = plateauService.SetPlateau(plateauInput);
                if (plateauResponse.Error != null)
                {
                    Console.WriteLine(plateauResponse.Error.ToString());
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Enter the rover location and direction: (-1 to Exit or calculate output)");
                    var roverLocationInput = Console.ReadLine();
                    if (roverLocationInput == "-1")
                    {
                        var calculationResponse = roverService.Calculate();
                        Console.WriteLine(calculationResponse);
                        break;
                    }
                    var roverLocationResponse = roverService.SetLocation(roverLocationInput);
                    if (roverLocationResponse.Error != null)
                    {
                        Console.WriteLine(roverLocationResponse.Error.ToString());
                        continue;
                    }
                    Console.WriteLine("Enter the rover path:");
                    var roverPathInput = Console.ReadLine();
                    if (roverPathInput == "-1")
                    {
                        break;
                    }
                    var roverPathResponse = roverService.SetPath(roverPathInput, roverLocationResponse.Value);
                    if (roverPathResponse.Error != null)
                    {
                        Console.WriteLine(roverPathResponse.Error.ToString());
                        break;
                    }
                }
            }
        }
    }
}
