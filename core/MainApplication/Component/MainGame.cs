using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using Squid;
using core.Component;

namespace MainApplication.Component
{
    

    class MainGame : Game
    {
        private Container container;

        protected override void Initialize()
        {

            Engine.DisplayFPS(true);
            GUI.Renderer = new RenderOpt();
            container = new GameContainer(this);
            container.start();

        }

    }
}
