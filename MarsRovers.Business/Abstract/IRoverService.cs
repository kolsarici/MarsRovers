using System;
using MarsRovers.Entities.Concrete;

namespace MarsRovers.Business.Abstract
{
    public interface IRoverService
    {
        Response<Rover> SetLocation(string input);

        Response<Rover> SetPath(string input, Rover rover);

        string Calculate();
    }
}
