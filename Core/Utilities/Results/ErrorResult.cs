﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {

        public ErrorResult(string messge) : base(success:false, messge)
        {
        }
        public ErrorResult() : base(success: false)
        {
        }
        
    }
}
