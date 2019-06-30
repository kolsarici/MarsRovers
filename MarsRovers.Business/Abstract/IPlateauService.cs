using System;
using MarsRovers.Entities.Concrete;

namespace MarsRovers.Business.Abstract
{
    public interface IPlateauService
    {
        Response<Plateau> SetPlateau(string input);
    }
}
