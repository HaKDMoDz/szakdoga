using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;
using core.Domain;

namespace core.Service
{
    public interface CombatService
    {
        Skill getSkill(CONST_TV_KEY key);
        void useSkill(Character target, Skill skill);
    }
}
