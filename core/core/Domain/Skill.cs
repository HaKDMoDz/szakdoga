using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service.attack;

namespace core.Domain
{
    public class Skill
    {
        private SkillStrategy attackStrategy;

        public SkillStrategy AttackStrategy
        {
            get
            {
                return attackStrategy;
            }
            set
            {
                attackStrategy = value;
            }
        }

        public void use(Character target)
        {

        }
    }
}
