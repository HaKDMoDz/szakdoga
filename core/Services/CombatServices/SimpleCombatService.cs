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
        private CombatRepository combabatRepository;

        public CombatRepository CombabatRepository
        {
            set
            {
                combabatRepository = value;
            }
        }

        public Skill getSkill(CONST_TV_KEY key)
        {
            return combabatRepository.getSkill(key);
        }
    }
}
