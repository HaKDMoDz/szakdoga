using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service.attack
{
    public interface SkillStrategy
    {
        void use(Character target, Skill skill);
    }
}
