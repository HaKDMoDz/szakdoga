using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using MTV3D65;
using core.Domain;

namespace core.Component
{
    public class Player : DrawableGameComponent
    {
        private TVActor actor;

        private PlayerService playerService;

        public PlayerService PlayerService
        {
            get
            {
                return playerService;
            }
            set
            {
                playerService = value;
            }
        }

        public Player(Game game) : base(game) { }

        public override void Update(GameTime time)
        {            
            actor.LookAtPoint(playerService.getLookAtPoint());
            setPosition(playerService.getPosition());
            base.Update(time);
        }

        public override void Load()
        {
            base.Load();

            int IdMat = Game.Materials.CreateLightMaterial(1, 1, 1, 1, 0.025f, 0, "WarriorMat");
            

            actor = Game.Scene.CreateActor("player");
            actor.LoadTVA("Characters/Player/Man/bind.TVA");
            actor.SetMaterial(IdMat, -1);
            actor.SetAnimationLoop(true);
            actor.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_NONE, 0, 1);
            actor.SetScale(15f, 15f, 15f);
            TV_3DVECTOR position = playerService.getPosition();
            actor.SetPosition(position.x, position.y, position.z);
            actor.PlayAnimation(1);
        }

        public override void Draw(GameTime time)
        {
            actor.Render();
            base.Draw(time);
        }

        private void setPosition(TV_3DVECTOR position)
        {
            actor.SetPosition(position.x, position.y, position.z);
        }

    }
}
