using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.Core
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ApiResult SuccessResult(string msg)
        {
            return new ApiResult { Success = true, Message = msg };
        }

        public static ApiResult Failure(string msg)
        {
            return new ApiResult { Success = false, Message = msg };
        }
    }

}
