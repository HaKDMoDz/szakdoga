using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;
using MTV3D65;

namespace Services.AnimationServices
{
    public class SimpleAnimationService : AnimationService
    {
        private Dictionary<CharacterName, Actor> actors = new Dictionary<CharacterName, Actor>();

        public void addAnimation()
        {
            throw new NotImplementedException();
        }

        public void registerActor(CharacterName name, Actor actor)
        {
            actors.Add(name, actor);
        }

        public void changeAnimation(CharacterAnimationState charAnimState, CharacterName character)
        {
            int i = 0;
            bool found = false;
            string[] animNames = Enum.GetNames(typeof(CharacterAnimationState));
            while (i < animNames.Length && !found)
            {
                CharacterAnimationState value = (CharacterAnimationState)Enum.Parse(typeof(CharacterAnimationState), animNames[i]);            
                if (charAnimState == value && actors[character].CharacterAnimState != value)
                {
                    bool animLoop = !(charAnimState == CharacterAnimationState.Die || charAnimState == CharacterAnimationState.Die1 || charAnimState == CharacterAnimationState.Die2);
                    setAnimationLoop(animLoop, character);
                    setAnimation(value, character);
                    found = true;
                }
                i++;
            }
        }

        private void setAnimation(CharacterAnimationState charAnimState, CharacterName character)
        {
            Actor actor = actors[character];
            String ch = "Characters/" + character.ToString().ToLower() + "/man/" + charAnimState + ".TVA";
            actor.Actor.ImportAnimations("Characters/" + character.ToString().ToLower() + "/man/" + charAnimState + ".TVA");
            actor.Actor.SetAnimationByName(charAnimState.ToString());
            actor.Actor.PlayAnimation(1);
            actor.CharacterAnimState = charAnimState;
        }

        private void setAnimationLoop(bool loop, CharacterName character)
        {
            Actor actor = actors[character];
            actor.Actor.SetAnimationLoop(loop);
        }
    }
}
