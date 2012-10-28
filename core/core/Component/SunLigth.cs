using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using core.Component;
using core.Service;

namespace core.Component
{
    public class SunLigth : GameComponent, LightService
    {
        public SunLigth(Game game)
            : base(game)
        {

        }

        public override void Load()
        {

            Int32 id = Game.Light.CreatePointLight(new MTV3D65.TV_3DVECTOR(), 1, 1, 1, 1000, "PointLight");
            Game.Light.SetSpecularLighting(false);
            //_lightPosition = new TV_3DVECTOR(1000,
            //    Landscape.GetHeight(1000, 1000) + 100,
            //    1000);
        }

    }
}
