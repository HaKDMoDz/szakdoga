using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;
using core.Service.attack;
using MTV3D65;
using core.Component;

namespace Services.PlayerServices
{
    public class SimplePlayerService : PlayerService
    {
        private const int LOSE_XP_IN_TOWN = 5;
        private const int LOSE_XP_IN_PLACE = 10;
        private const int LOSE_GOLD_IN_TOWN = 2;
        private const int LOSE_GOLD_IN_PLACE = 5;

        private Statistics statistics;
        private Accessories accessories;
        private CombatService combatService;
        private Landscape landscape;

        public Landscape Landscape
        {
            set
            {
                landscape = value;
            }
        }

        public CombatService CombatService
        {
            set
            {
                this.combatService = value;
            }
        }

        public Statistics Statistics
        {
            set
            {
                this.statistics = value;
            }
        }

        public SimplePlayerService(CombatService combatService, Statistics statistics, Landscape landscape)
        {
            this.combatService = combatService;
            this.statistics = statistics;
            this.landscape = landscape;
        }

        public void rebirth(RebirthLocation location)
        {
            if (location.Equals(RebirthLocation.TOWN))
            {
                statistics.HealthPoint = statistics.MaxHealthPoint * 0.8f;
            }
            else
            {
                statistics.HealthPoint = statistics.MaxHealthPoint * 0.8f;
            }
        }

        public void kill()
        {
            playerDead();
        }

        public void receiveDamage(float damage)
        {
            statistics.HealthPoint -= damage;
            if (statistics.HealthPoint <= 0)
            {
                playerDead();
            }
        }

        private void playerDead()
        {
            statistics.IsDead = true;
        }

        public void useSkill(CONST_TV_KEY key)
        {
            Skill skill = combatService.getSkill(key);
            if (skill != null)
            {
                combatService.useSkill(new Statistics(), skill);
            }
        }

        public TV_3DVECTOR getPosition()
        {
            TV_3DVECTOR ret = statistics.Position;
            ret.y = landscape.GetHeight(ret.x, ret.z);
            return ret;
        }

        public TV_3DVECTOR getLookAtPoint()
        {
            return statistics.LookAtPoint;
        }
    }
}
