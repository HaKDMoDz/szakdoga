using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service
{
    public interface SkillService
    {
        void addSkill(SkillName skillName);
        void addLearnedSkill(SkillName skillName);
        void upgradeLearnedSkill(SkillName skillName);
        bool isLearnedSkill(SkillName skillName);
    }
}
