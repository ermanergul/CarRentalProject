using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Abstract
{
    public interface IResult
    {


        //Set etme işlemi constructor ile classta olacak olacak
        bool Success { get; }
        string Message { get; }
    }
}
