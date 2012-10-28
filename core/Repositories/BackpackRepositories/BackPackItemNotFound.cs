using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.BackpackRepositories
{
    class BackPackItemNotFound : Exception
    {
        public BackPackItemNotFound(string msg)
            :base(msg)
        {
        }
    }
}
