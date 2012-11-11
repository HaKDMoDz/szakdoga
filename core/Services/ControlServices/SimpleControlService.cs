using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core;
using MTV3D65;
using core.Domain;
using core.Collision;
using core.Component;

namespace Services.ControlServices
{
    public class SimpleControlService : ControlService
    {
        private Landscape landscape;
        private AnimationService animationService;

        public SimpleControlService(Landscape landscape)
        {
            this.landscape = landscape;
        }

        public bool goToTarget(Statistics statistics, TV_3DVECTOR targetPos)
        {
            TV_3DVECTOR vec = statistics.Position;
            if (getDistance(vec, targetPos) > 3)
            {
                float frameTime = Game.Engine.TimeElapsed();
                float movementSpeed = 0.1f;

                TV_3DVECTOR dV2 = new TV_3DVECTOR();
                float s = frameTime * movementSpeed;
                Game.Math.TVVec3Scale(ref dV2, getDirection(statistics, targetPos), s);

                Game.Math.TVVec3Add(ref vec, statistics.Position, dV2);
                vec.y = landscape.GetHeight(vec.x, vec.z);
                statistics.Position = vec;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void turnToTargetDirection(Statistics statistics, DetectCollision collision)
        {
            statistics.LookAtPoint = collision.getTargetPosition();
        }

        private TV_3DVECTOR getDirection(Statistics statistics, TV_3DVECTOR targetPos)
        {
            var pos = statistics.Position;
            TV_3DVECTOR dVector = new TV_3DVECTOR();
            Game.Math.TVVec3Subtract(ref dVector, targetPos, pos);
            Game.Math.TVVec3Normalize(ref dVector, dVector);
            return dVector;
        }

        private float getDistance(TV_3DVECTOR player, MTV3D65.TV_3DVECTOR target)
        {
            float dis = Game.Math.GetDistance3D(player.x, player.y, player.z, target.x, target.y, target.z);
            return dis;
        }

    }
}
