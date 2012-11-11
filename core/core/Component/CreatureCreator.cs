using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;
using MTV3D65;

namespace core.Component
{
    public class CreatureCreator
    {
        private CreatureService creatureService;

        public CreatureService CreatureService
        {
            set
            {
                creatureService = value;
            }
        }

        public CreatureCreator(){ }

        public void Load()
        {
            Statistics statistics = new Statistics();
            statistics.HealthPoint = 100;
            statistics.Position = new TV_3DVECTOR(10, 0, 10);
            statistics.MaxHealthPoint = 120;    
            creatureService.createCreature(CharacterName.DWARF, statistics);
        }
    }
}
