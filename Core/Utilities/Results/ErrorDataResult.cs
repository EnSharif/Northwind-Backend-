using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data,  string messge) : base(data, success: false, messge)
        {
        }
        public ErrorDataResult(T data) : base(data, success: false)
        {
        }
        public ErrorDataResult(string messge) : base(default, success: false, messge)
        {
        }
        public ErrorDataResult() : base(default, success: false)
        {
        }
    }
}
