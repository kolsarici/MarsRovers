using System;
using MarsRovers.Entities.Enums;

namespace MarsRovers.Entities.Concrete
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public string Path { get; set; }
    }
}
