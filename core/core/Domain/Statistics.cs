using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public class Statistics : Character
    {
        private float healtPoint;
        private float maxHealtPoint;
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

        public float MaxHealthPoint
        {
            set
            {
                maxHealtPoint = value;
            }
            get
            {
                return maxHealtPoint;
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

        public void damage(float damage)
        {
            healtPoint -= damage;
        }

        public void addBuff()
        {
            throw new NotImplementedException();
        }

        public void heal(float healtPoint)
        {
            throw new NotImplementedException();
        }

        public void curse()
        {
            throw new NotImplementedException();
        }
    }
}
