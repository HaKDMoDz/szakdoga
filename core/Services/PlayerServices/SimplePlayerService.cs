using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;
using core.Service.attack;

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

        public Statistics Statistics
        {
            set
            {
                this.statistics = value;
            }
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


        public void useSkill(SkillStrategy skillStrategy)
        {
            skillStrategy.use();
        }
    }
}
