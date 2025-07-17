using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {

        public SuccessDataResult(T data, string messge) : base(data, success:true, messge)
        {
        }
        public SuccessDataResult(T data) : base(data, success: true)
        {
        }
        public SuccessDataResult(string messge):base(default,success:true,messge)
        {
        }
        public SuccessDataResult():base(default,success:true)
        {
        }
    }
}
