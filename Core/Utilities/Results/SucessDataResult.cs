using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SucessDataResult<T> : DataResult<T>
    {

        public SucessDataResult(T data, string messge) : base(data, success:true, messge)
        {
        }
        public SucessDataResult(T data) : base(data, success: true)
        {
        }
        public SucessDataResult(string messge):base(default,success:true,messge)
        {
        }
        public SucessDataResult():base(default,success:true)
        {
        }
    }
}
