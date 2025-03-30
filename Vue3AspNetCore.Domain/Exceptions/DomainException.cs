using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public string ErrorCode { get; }

        protected DomainException(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}