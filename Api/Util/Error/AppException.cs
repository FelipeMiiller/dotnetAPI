using System.Globalization;
using System.Net;

namespace Api.Util.Error
{
    public class AppException : Exception
    {
        public int Code = (int)HttpStatusCode.InternalServerError;
        public string Title = "Internal Server Error";



        public AppException(int Code, string Title, string message) : base(message)
        {
            this.Code = Code;
            this.Title = Title;
        }


        public AppException(string message) : base(message) { }

    }


    public class AppExceptionDB : AppException
    {

        public AppExceptionDB(int Code, string message) : base(Code, "DB Error", message) { }

    }
}