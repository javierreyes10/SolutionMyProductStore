using System;

namespace MyProductStore.Application.Exceptions
{
    public class ApiBusinessException : Exception
    {
        public ApiBusinessException()
        {
        }

        public ApiBusinessException(string message) : base(message)
        {
        }
    }
}
