using System;
using System.Collections.Generic;
using System.Linq;
using MarsRovers.Business.Abstract;
using MarsRovers.Entities.Concrete;

namespace MarsRovers.Business.Concrete.Managers
{
    public class PlateauManager : IPlateauService
    {
        public static Plateau plateau { get; set; }

        public Response<Plateau> SetPlateau(string input)
        {
            var response = new Response<Plateau>();
            var values = input.Split(" ").ToList();
            if (values.Count != 2)
            {
                response.Error = new Error("E101", "Please enter 2 integer values.", "Sample Data: 5 5");
                return response;
            }

            plateau = new Plateau();
            RoverManager.roverList = new List<Rover>();
            plateau.MinX = 0;
            plateau.MinY = 0;

            int maxX = 0;
            int maxY = 0;
            if (Int32.TryParse(values[0], out maxX) && Int32.TryParse(values[1], out maxY))
            {
                plateau.MaxX = maxX;
                plateau.MaxY = maxY;
                response.Value = plateau;
                return response;
            }
            else
            {
                response.Error = new Error("E102", "Please enter valid integer values.", "Value 1 -> " + values[0] + "\nValue 2 -> " + values[1] + ": Check your values.");
                return response;
            }
        }
    }
}
