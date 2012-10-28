using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;
using MTV3D65;

namespace core.Repository
{
    public interface CombatRepository
    {
        void addSkill(CONST_TV_KEY key, Skill skill);
        void removeSkill(CONST_TV_KEY key);
        Skill getSkill(CONST_TV_KEY key);
        Dictionary<CONST_TV_KEY, Skill> getAllSkill();
    }
}
