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
        private Player player;

        public Player Player
        {
            set
            {
                this.player = value;
            }
        }

        public void rebirth()
        {
            throw new NotImplementedException();
        }

        public void kill()
        {
            throw new NotImplementedException();
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
