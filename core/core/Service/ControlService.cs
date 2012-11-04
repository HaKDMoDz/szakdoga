using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Collision;
using MTV3D65;

namespace core.Service
{
    public interface ControlService
    {
        void goToTarget(TV_3DVECTOR targetPos);
        void turnToTargetDirection(DetectCollision collision);
    }
}
