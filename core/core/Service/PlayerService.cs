using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service
{
    public interface PlayerService
    {        
        void rebirth();
        void receiveDamage(float damage);
        void kill();
        void attack();
        Player Player { set; }
    }
}
