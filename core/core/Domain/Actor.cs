using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;

namespace core.Domain
{
    public interface Actor
    {
        CharacterAnimationState CharacterAnimState { get; set; }

        TVActor Actor { get; set; }
    }
}
