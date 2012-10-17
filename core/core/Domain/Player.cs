using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public class Player : DrawableGameComponent
    {
        private float healtPoint;
        private bool isDead;

        public float HealthPoint
        {
            set
            {
                healtPoint = value;
            }
            get
            {
                return healtPoint;
            }
        }
        public bool IsDead
        {
            set
            {
                isDead = value;
            }
            get
            {
                return isDead;
            }
        }

        public Player(Game game)
            : base(game)
        {
        }

    }
}
