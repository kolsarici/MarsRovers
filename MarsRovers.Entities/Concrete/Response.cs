using System;
namespace MarsRovers.Entities.Concrete
{
    public class Response<T>
    {
        public Error Error { get; set; }
        public T Value { get; set; }
    }
}
