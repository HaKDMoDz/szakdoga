using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;
using core.Service.attack;
using MTV3D65;

namespace core.Service
{
    public interface PlayerService
    {        
        void rebirth(RebirthLocation location);
        void receiveDamage(float damage);
        void kill();
        void useSkill(CONST_TV_KEY key);
        TV_3DVECTOR getPosition();
        void setPosition(TV_3DVECTOR position);
        Statistics getStatistics();
        TV_3DVECTOR getLookAtPoint();
    }
}
