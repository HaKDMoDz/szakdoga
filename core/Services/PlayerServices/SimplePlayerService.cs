using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;

namespace Services.PlayerServices
{
    public class SimplePlayerService : PlayerService
    {
        private const int LOSE_XP_IN_TOWN = 5;
        private const int LOSE_XP_IN_PLACE = 10;
        private const int LOSE_GOLD_IN_TOWN = 2;
        private const int LOSE_GOLD_IN_PLACE = 5;

        private Player player;

        public Player Player
        {
            set
            {
                this.player = value;
            }
        }

        public void rebirth(RebirthLocation location)
        {
            if (location.Equals(RebirthLocation.TOWN))
            {
                player.HealthPoint = player.MaxHealthPoint * 0.8f;
            }
            else
            {
                player.HealthPoint = player.MaxHealthPoint * 0.8f;
            }
        }

        public void kill()
        {
            playerDead();
        }

        public void attack()
        {
            throw new NotImplementedException();
        }

        public void receiveDamage(float damage)
        {
            player.HealthPoint -= damage;
            if (player.HealthPoint <= 0)
            {
                playerDead();
            }
        }

        private void playerDead()
        {
            player.IsDead = true;
        }
    }
}
