using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.BackpackRepositories
{
    class NotEnoughtItemException : Exception
    {
        public NotEnoughtItemException(string msg)
            :base(msg)
        {
        }
    }
}
