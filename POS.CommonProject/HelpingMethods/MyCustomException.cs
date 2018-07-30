using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message, Exception innerException)
            : base(message, innerException)
        {
            if (innerException != null)
            {
                message += innerException.ToString();
            }
        }
        /// Initialize new instance of the class
        public MyCustomException()
            : base()
        {
        }
        ///  Intialize the new instance of the <see cref="MyCustomException"/> class with a specified error message
        ///  <param name=message"> The error message taht explain the reason of the message.</param>
        public MyCustomException(string message)
            : base(message)
        {

        }
    }
    public class BALException : Exception
    {
        public BALException(string message, Exception innerException)
            : base(message, innerException)
        {
            if (innerException != null)
            {
                message += innerException.ToString();
            }
        }
        /// Initialize new instance of the class
        public BALException()
            : base()
        {
        }
        ///  Intialize the new instance of the <see cref="MyCustomException"/> class with a specified error message
        ///  <param name=message"> The error message taht explain the reason of the message.</param>
        public BALException(string message)
            : base(message)
        {

        }
    }
    public class DALException : Exception
    {
        public DALException(string message, Exception innerException)
            : base(message, innerException)
        {
            if (innerException != null)
            {
                message += innerException.ToString();
            }
        }
        /// Initialize new instance of the class
        public DALException()
            : base()
        {
        }
        ///  Intialize the new instance of the <see cref="MyCustomException"/> class with a specified error message
        ///  <param name=message"> The error message taht explain the reason of the message.</param>
        public DALException(string message)
            : base(message)
        {

        }
    }
    public class APIException : Exception
    {
        public APIException(string message, Exception innerException)
            : base(message, innerException)
        {
            if (innerException != null)
            {
                message += innerException.ToString();
            }
        }
        /// Initialize new instance of the class
        public APIException()
            : base()
        {
        }
        ///  Intialize the new instance of the <see cref="MyCustomException"/> class with a specified error message
        ///  <param name=message"> The error message taht explain the reason of the message.</param>
        public APIException(string message)
            : base(message)
        {

        }
    }
    public class UIException : Exception
    {
        public UIException(string message, Exception innerException)
            : base(message, innerException)
        {
            if (innerException != null)
            {
                message += innerException.ToString();
            }
        }
        /// Initialize new instance of the class
        public UIException()
            : base()
        {
        }
        ///  Intialize the new instance of the <see cref="MyCustomException"/> class with a specified error message
        ///  <param name=message"> The error message taht explain the reason of the message.</param>
        public UIException(string message)
            : base(message)
        {

        }
    }
}
