using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using MTV3D65;

namespace MainApplication.Component.Characters
{
    class Rancor : DrawableGameComponent
    {
        private TVActor actor;

        public Rancor(Game game):base(game)
        {

        }

        public override void Load()
        {
            actor = Game.Scene.CreateActor();
            actor.SetPosition(0, 0, 0);
            actor.LoadTVA("Characters/Dwarf/idle.TVA");
            actor.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_NONE, 0, 1);
            actor.SetScale(10, 10, 10);
            base.Load();
        }

        public override void Draw(GameTime time)
        {
            actor.Render();
            base.Draw(time);
        }
    }
}
