using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    public abstract class DrawableGameComponent : GameComponent
    {
        public DrawableGameComponent(Game game) : base(game) { }
        public virtual void Draw(GameTime time) { }
    }
}
