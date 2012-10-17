using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    public abstract class GameComponent
    {
        public static Game Game { get; private set; }
        public GameComponent(Game game) { Game = game; }
        public virtual void Update(GameTime time) { }
        public virtual void Load() { }
        public virtual void Unload() { }
    }


}
