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

        public Player(Game game) : base(game) { }

        public override void Update(GameTime time)
        {            
            base.Update(time);
        }
    }
}
