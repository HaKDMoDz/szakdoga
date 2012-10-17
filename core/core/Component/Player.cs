using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;

namespace core.Component
{
    public class Player : DrawableGameComponent
    {
        private PlayerService playerService;

        public override void Update(GameTime time)
        {
            playerService.receiveDamage(10f);
            base.Update(time);
        }
    }
}
