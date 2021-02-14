using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class ErrorResult:Result
    {
        //message & unsuccessfull
        public ErrorResult(string message):base(false,message)
        {

        }
        public ErrorResult():base(false)
        {

        }
    }
}
