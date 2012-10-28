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
        private SkillName skillName;
        private SkillType skillCast;

        public SkillName SkillName
        {
            get
            {
                return skillName;
            }
            set
            {
                skillName = value;
            }
        }
        public SkillType SkillType
        {
            get
            {
                return skillCast;
            }
            set
            {
                skillCast = value;
            }
        }
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
            attackStrategy.use(target, this);
        }
    }
}
