using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using Squid;
using core.Component;

namespace MainApplication.Scenes
{
    public class GameScene : Scene
    {
        private Desktop desktop;

        public GameScene(Game game, Desktop desktop)
            : base(game)
        {
            this.desktop = desktop;
        }

        public Desktop Desktop
        {
            set
            {
                desktop = value;
            }
        }

        public override void Load()
        {
            Game.Engine.ShowWinCursor(false);            
            desktop.ShowCursor = true;
            base.Load();
        }

        public override void Draw(GameTime time)
        {
            desktop.Size = new Squid.Point(Game.Engine.GetViewport().GetWidth(), Game.Engine.GetViewport().GetHeight());
            desktop.Update();
            desktop.Draw();
        }
    }
}
