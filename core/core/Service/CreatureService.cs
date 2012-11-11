using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;
using core.Domain;
using core.Component;

namespace core.Service
{
    public interface CreatureService
    {
        TV_3DVECTOR getPosition(string uniqueName);

        Creature createCreature(CharacterName type, Statistics statistics);
    }
}
