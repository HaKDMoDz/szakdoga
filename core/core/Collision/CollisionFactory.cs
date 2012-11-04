using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;
using core.Collision.Landscape;
using core.Collision.Actor;

namespace core.Collision
{
    public class CollisionFactory
    {
        public static DetectCollision getDetectCollision(TV_COLLISIONRESULT collResult)
        {
            DetectCollision ret = null;
            if (collResult.eCollidedObjectType == CONST_TV_OBJECT_TYPE.TV_OBJECT_LANDSCAPE)
            {
                ret = new LandscapeDetectCollision(collResult);
            }
            else if (collResult.eCollidedObjectType == CONST_TV_OBJECT_TYPE.TV_OBJECT_ACTOR)
            {
                ret = new ActorDetectCollision(collResult);
            }
            else
            {
                throw new NullReferenceException("Not valid collResult!");
            }

            return ret;
        }
    }
}
