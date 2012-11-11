using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;
using MTV3D65;
using core.Service;

namespace core.Component
{
    public class Creature : DrawableGameComponent, Actor
    {
        private TVActor tvActor;
        private CharacterAnimationState animState;


        public Creature(Game game) : base(game) { }

        private CharacterName characterName;

        private String uniqueName;

        public String UniqueName
        {
            get
            {
                return uniqueName;
            }
            set
            {
                uniqueName = value;
            }
        }

        private Statistics statistics;

        public Statistics Statistics
        {
            get
            {
                return statistics;
            }
            set
            {
                statistics = value;
            }
        }

        public CharacterName CharacterName
        {
            get
            {
                return characterName;
            }
            set
            {
                characterName = value;
            }
        }

        private CreatureService creatureService;
        private AnimationService animationService;

        public CreatureService CreatureService
        {
            set
            {
                creatureService = value;
            }
        }

        public AnimationService AnimationService
        {
            set
            {
                animationService = value;
            }
        }

        public override void Load()
        {
            base.Load();

            int IdMat = Game.Materials.CreateLightMaterial(1, 1, 1, 1, 0.025f, 0, "WarriorMat");


            tvActor = Game.Scene.CreateActor(characterName.ToString());
            tvActor.LoadTVA("Characters/"+characterName+"/bind.TVA");
            tvActor.SetMaterial(IdMat, -1);
            tvActor.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_NONE, 0, 1);
            tvActor.SetScale(15f, 15f, 15f);
            TV_3DVECTOR position = creatureService.getPosition(uniqueName);
            tvActor.SetPosition(position.x, position.y, position.z);

            animationService.registerActor(characterName, this);
            CharacterAnimState = CharacterAnimationState.AREACAST;
            animationService.changeAnimation(CharacterAnimationState.IDLE, characterName);
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

        public override void Update(GameTime time)
        {
            //tvActor.LookAtPoint(creatureService.getPosition());
            setPosition(creatureService.getPosition(uniqueName));
            base.Update(time);
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
