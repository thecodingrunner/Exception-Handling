using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    internal class InputResult
    {
        public bool Success;
        public double[] Result;
        public string Message;

        public InputResult(bool success, double[]? result, string message)
        {
            Success = success;
            Result = result;
            Message = message;
        }
    }
}
