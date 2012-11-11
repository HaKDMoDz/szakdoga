using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public interface Character
    {
        void heal(float healtPoint);
        void damage(float damage);
        void addBuff();
        void removeBuff();
        void addCurse();
        void removeCurse();
    }
}
