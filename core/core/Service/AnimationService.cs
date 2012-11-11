using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service
{
    public interface AnimationService
    {
        void addAnimation();
        void changeAnimation(CharacterAnimationState charAnimState, CharacterName character);
        void registerActor(CharacterName name, Actor actor);
    }
}
