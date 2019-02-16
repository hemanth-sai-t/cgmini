using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHSException
{

    public class EasyHousingSolutionException : ApplicationException
    {
        public EasyHousingSolutionException() : base() { }

        public EasyHousingSolutionException(string message) : base(message) { }

        public EasyHousingSolutionException(string message, Exception innerException) : base(message, innerException) { }
    }
}

