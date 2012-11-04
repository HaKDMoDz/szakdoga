using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;

namespace core.Collision.Landscape
{
    public class LandscapeDetectCollision : DetectCollision
    {
        private TV_COLLISIONRESULT collResult;

        public LandscapeDetectCollision(TV_COLLISIONRESULT collResult)
        {
            this.collResult = collResult;
        }

        public TV_3DVECTOR getTargetPosition()
        {
            return collResult.vCollisionImpact;
        }
    }
}
