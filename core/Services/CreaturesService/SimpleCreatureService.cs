using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Component;
using core.Domain;
using MTV3D65;
using core;

namespace Services.CreaturesService
{
    public class SimpleCreatureService : CreatureService
    {
        private Dictionary<String, Creature> creatures = new Dictionary<string, Creature>();
        private Container container;
        private Landscape landscape;

        public Container Container
        {
            set
            {
                container = value;
            }
        }

        public Landscape Landscape
        {
            set
            {
                landscape = value;
            }
        }

        private int id = 0;

        public TV_3DVECTOR getPosition(string uniqueName)
        {
            TV_3DVECTOR pos = creatures[uniqueName].Statistics.Position;
            TV_3DVECTOR newPos = new TV_3DVECTOR(pos.x, landscape.GetHeight(pos.x, pos.z), pos.z);
            return newPos;
        }

        public Creature createCreature(CharacterName type, Statistics statistics)
        {
            String uniqueName = type.ToString() + id;

            Creature creature = new Creature(container.getObject<Game>("mainGame"));
            creature.UniqueName = uniqueName;
            creature.Statistics = statistics;
            creature.CreatureService = this;
            creature.CharacterName = type;
            creature.AnimationService = container.getObject<AnimationService>("animationService");

            container.addComponent(creature, uniqueName);
            creatures.Add(uniqueName, creature);
            id++;
            return creature;
        }
    }
}
