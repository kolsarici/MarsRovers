using System;
namespace MarsRovers.Entities.Concrete
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public Error(string code, string message, string detail)
        {
            Code = code;
            Message = message;
            Detail = detail;
        }

        public override string ToString()
        {
            var detail = String.IsNullOrEmpty(Detail) ? "" : "\nDetail:  " + Detail;
            return "---------------------------" +
                   "\nErrorCode: " + Code +
                   "\nMessage: " + Message + detail +
                   "\n---------------------------";
        }
    }
}
