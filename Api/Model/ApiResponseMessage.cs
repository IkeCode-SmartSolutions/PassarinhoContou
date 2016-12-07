using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassarinhoContou.Api.Model
{
    public class ApiResponseMessage
    {
        public string Message { get; internal set; }
        public Exception Exception { get; internal set; }

        public ApiResponseMessage(string message)
        {
            this.Message = message;
        }

        public ApiResponseMessage(Exception ex)
            : this(ex.Message)
        {
            this.Exception = ex;
        }
    }
}
