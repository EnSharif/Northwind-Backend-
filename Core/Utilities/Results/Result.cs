using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success,string messge):this(success)
        {
            Messge = messge;
           // Success = success; böylede yazabiliriz
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Messge { get; }
    }
}
