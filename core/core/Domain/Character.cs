using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public interface Character
    {
        void damage(float damage);
        void addBuff();
        void heal(float healtPoint);
        void curse();
    }
}
