using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Shared
{
    public static class Functional
    {
        public static Result Success(object value = null)
        {
            return new Result { IsFailure = false, Value = value};
        }

        public static Result Failure(string error = null)
        {
            return new Result { IsFailure = true, Value = error };
        }
    }
}
