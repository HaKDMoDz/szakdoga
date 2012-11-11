using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using MTV3D65;
using core.Domain;

namespace core.Component
{
    public class Player : DrawableGameComponent, Actor
    {
        private TVActor tvActor;
        private CharacterAnimationState animState;

        private PlayerService playerService;
        private AnimationService animationService;

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

        public AnimationService AnimationService
        {
            set
            {
                animationService = value;
            }
        }

        public Player(Game game) : base(game) { }

        public override void Update(GameTime time)
        {            
            tvActor.LookAtPoint(playerService.getLookAtPoint());
            setPosition(playerService.getPosition());
            base.Update(time);
        }

        public override void Load()
        {
            base.Load();

            int IdMat = Game.Materials.CreateLightMaterial(1, 1, 1, 1, 0.025f, 0, "WarriorMat");
            

            tvActor = Game.Scene.CreateActor("player");
            tvActor.LoadTVA("Characters/Player/Man/bind.TVA");
            tvActor.SetMaterial(IdMat, -1);
            tvActor.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_NONE, 0, 1);
            tvActor.SetScale(15f, 15f, 15f);
            TV_3DVECTOR position = playerService.getPosition();
            tvActor.SetPosition(position.x, position.y, position.z);

            animationService.registerActor(CharacterName.PLAYER, this);
            CharacterAnimState = CharacterAnimationState.AREACAST;

            animationService.changeAnimation(CharacterAnimationState.IDLE, CharacterName.PLAYER);

        }

        public override void Draw(GameTime time)
        {
            tvActor.Render();
            base.Draw(time);
        }

        private void setPosition(TV_3DVECTOR position)
        {
            tvActor.SetPosition(position.x, position.y, position.z);
        }

        public CharacterAnimationState CharacterAnimState
        {
            get
            {
                return animState;
            }
            set
            {
                animState = value;
            }
        }

        public TVActor Actor
        {
            get
            {
                return tvActor;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
