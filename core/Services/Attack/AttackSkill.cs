using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service.attack;
using core.Domain;

namespace Services.Attack
{
    public class AttackSkill : SkillStrategy
    {
        public void use(Character target, Skill skill)
        {
            target.damage(100);
        }
    }
}
