using Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class Result : IResult
    {
        //BASE CLASS


        //Constructor ile set edildi
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }

        //Overrive ile diğer durum kontrol edildi
        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
    }
}
