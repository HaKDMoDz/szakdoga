using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Collision;
using MTV3D65;
using core.Domain;

namespace core.Service
{
    public interface ControlService
    {
        bool goToTarget(Statistics statistics, TV_3DVECTOR targetPos);
        void turnToTargetDirection(Statistics statistics, DetectCollision collision);
    }
}
