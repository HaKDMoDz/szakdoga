using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.CombatRepositories
{
    class SkillSlotEmptyException : Exception
    {

        public SkillSlotEmptyException(string msg)
            : base(msg)
        {
        }
    }
}
