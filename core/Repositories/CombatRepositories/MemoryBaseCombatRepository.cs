using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;
using MTV3D65;
using core.Repository;

namespace Repositories.CombatRepositories
{
    public class MemoryBaseCombatRepository : CombatRepository
    {
        private Dictionary<CONST_TV_KEY, Skill> skills = new Dictionary<CONST_TV_KEY, Skill>();

        public void addSkill(CONST_TV_KEY key, Skill skill)
        {
            if (skills.Count < 12)
            {
                skills.Add(key, skill);
            }
        }

        public void removeSkill(CONST_TV_KEY key)
        {
            skills.Remove(key);
        }

        public Skill getSkill(CONST_TV_KEY key)
        {
            return skills[key];
        }

        public Dictionary<CONST_TV_KEY, Skill> getAllSkill()
        {
            return skills;
        }
    }
}
