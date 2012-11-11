using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using MTV3D65;
using core.Collision.Landscape;
using core.Collision;
using core.input;
using core.Domain;

namespace core.Component
{
    public class Movement : GameComponent
    {
        private ControlService controlService;
        private WindowService windowService;
        private InputManager inputManager;
        private MouseEvent mouseEvent;
        private TV_3DVECTOR targetPos;
        private AnimationService animationService;
        private PlayerService playerService;

        public Movement(Game game) : base(game) { }


        public MouseEvent MouseEvent
        {
            set
            {
                mouseEvent = value;
            }
        }

        public ControlService ControlService
        {
            set
            {
                controlService = value;
            }
        }

        public AnimationService AnimationService
        {
            set
            {
                animationService = value;
            }
        }

        public WindowService WindowService
        {
            set
            {
                windowService = value;
            }
        }

        public InputManager InputManager
        {
            set
            {
                inputManager = value;
            }
        }

        public override void Update(GameTime time)
        {
            TV_COLLISIONRESULT collResult = new TV_COLLISIONRESULT();
            if (mouseEvent.Click() && 
                Game.Scene.MousePickEx(inputManager.MouseAbsX, inputManager.MouseAbsY, ref collResult) &&
                !windowService.clickInWindowArea())
            {
                try
                {
                    controlService.turnToTargetDirection(playerService.getStatistics(), CollisionFactory.getDetectCollision(collResult));
                    targetPos = collResult.vCollisionImpact;
                }
                catch
                {

                }
            }
            if (controlService.goToTarget(playerService.getStatistics(), targetPos))
            {
                animationService.changeAnimation(CharacterAnimationState.RUN, CharacterName.PLAYER);
            }
            else
            {
                animationService.changeAnimation(CharacterAnimationState.IDLE, CharacterName.PLAYER);
            }
            base.Update(time);
        }

        public PlayerService PlayerService
        {
            set
            {
                playerService = value;
            }
        }
    }
}
