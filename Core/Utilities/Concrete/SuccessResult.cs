using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class SuccessResult:Result
    {
        //mesaj
        public SuccessResult(string message):base(true,message)
        {

        }

        //null
        public SuccessResult():base(true)
        {

        }
    }
}
