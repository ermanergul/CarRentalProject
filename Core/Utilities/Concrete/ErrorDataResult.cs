using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        //Data - Message 
        public ErrorDataResult(T data,string message):base(data,false,message)
        {

        }


        //Data
        public ErrorDataResult(T data):base(data,false)
        {

        }

        //Message
        public ErrorDataResult(string message):base(default,false,message)
        {

        }

        //NULL
        public ErrorDataResult():base(default,false)
        {

        }
    }
}
