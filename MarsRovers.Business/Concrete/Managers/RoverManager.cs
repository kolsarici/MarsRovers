using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MarsRovers.Business.Abstract;
using MarsRovers.Business.ExtensionMethods;
using MarsRovers.Entities.Concrete;
using MarsRovers.Entities.Enums;

namespace MarsRovers.Business.Concrete.Managers
{
    public class RoverManager : IRoverService
    {
        public static List<Rover> roverList { get; set; }

        public Response<Rover> SetLocation(string input)
        {
            var response = new Response<Rover>();

            var values = input.Split(" ").ToList();
            if (values.Count != 3)
            {
                response.Error = new Error("E201", "Please enter two integer values and one direction.", "Sample Data: 1 2 N");
                return response;
            }

            var rover = new Rover();


            int x = 0;
            int y = 0;
            var direction = Direction.N;
            if (Int32.TryParse(values[0], out x) && Int32.TryParse(values[1], out y) && Enum.TryParse<Direction>(values[2], out direction))
            {
                if (x > PlateauManager.plateau.MaxX || y > PlateauManager.plateau.MaxY)
                {
                    response.Error = new Error("E202", "Plateau borders exceeded.", "Please enter integers between " + PlateauManager.plateau.MaxX + " and " + PlateauManager.plateau.MaxY);
                    return response;
                }
                rover.X = x;
                rover.Y = y;
                rover.Direction = direction;
                response.Value = rover;
                return response;
            }
            else
            {
                response.Error = new Error("E203", "Please enter valid integer values.", "Value1 -> " + values[0] + "\nValue2 -> " + values[1] + "\nValue3 -> " + values[2] + "\nCheck your values.");
                return response;
            }
        }

        public Response<Rover> SetPath(string input, Rover rover)
        {
            var response = new Response<Rover>();

            foreach (var item in input)
            {
                if (item != 'L' && item != 'M' && item != 'R')
                {
                    response.Error = new Error("E204", "Please enter L,R or M for path.", "Sample Data: LMLMLMLMM");
                    return response;
                }
            }

            rover.Path = input;
            response.Value = rover;
            roverList.Add(rover);
            return response;
        }

        public string Calculate()
        {
            var response = "";
            if (roverList.Count > 0)
            {
                foreach (var rover in roverList)
                {
                    foreach (var p in rover.Path)
                    {
                        if ((Path)Enum.Parse(typeof(Path), p.ToString()) == Path.M)
                        {
                            Move(rover);
                        }
                        else
                        {
                            rover.Direction = CalculateDirection(rover.Direction, (Path)Enum.Parse(typeof(Path), p.ToString()));
                        }
                    }
                    var outOfRangeMessage = IsRoverOutOfRange(rover) ? " (Connection to the rover has been lost)" : "";
                    response += rover.X + " " + rover.Y + " " + rover.Direction.ToString() + outOfRangeMessage + "\n";
                }
            }
            return response;
        }

        public Direction CalculateDirection(Direction direction, Path path)
        {
            int mod = (Convert.ToInt16(direction) + Convert.ToInt16(path)) % 4;
            return mod < 0 ? (Direction)mod + 4 : (Direction)mod;
        }

        public void Move(Rover rover)
        {
            var plateauTargetList = rover.Direction.GetDescription().Split(",");
            rover.X += Convert.ToInt16(plateauTargetList[0]);
            rover.Y += Convert.ToInt16(plateauTargetList[1]);
        }

        public bool IsRoverOutOfRange(Rover rover)
        {
            if(rover.X > PlateauManager.plateau.MaxX || rover.Y > PlateauManager.plateau.MaxY || rover.X < PlateauManager.plateau.MinX || rover.Y < PlateauManager.plateau.MinY)
            {
                return true;
            }
            return false;
        }
    }
}