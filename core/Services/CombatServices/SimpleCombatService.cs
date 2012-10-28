using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Repository;
using core.Service;
using MTV3D65;
using core.Domain;

namespace Services.CombatServices
{
    public class SimpleCombatService : CombatService
    {
        private CombatRepository combatRepository;

        public CombatRepository CombatRepository
        {
            set
            {
                combatRepository = value;
            }
        }

        public SimpleCombatService(CombatRepository combatRepository)
        {
            this.combatRepository = combatRepository;
        }

        public Skill getSkill(CONST_TV_KEY key)
        {
            return combatRepository.getSkill(key);
        }

        public void useSkill(Character target, Skill skill)
        {            
            skill.use(target);
        }
    }
}
