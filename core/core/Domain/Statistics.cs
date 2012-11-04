using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;

namespace core.Domain
{
    public class Statistics : Character
    {
        private float healtPoint;
        private float maxHealtPoint;
        private bool isDead;
        private TV_3DVECTOR position;
        private TV_3DVECTOR lookAtPoint;

        public TV_3DVECTOR Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

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

        public TV_3DVECTOR LookAtPoint
        {
            get
            {
                return lookAtPoint;
            }
            set
            {
                lookAtPoint = value;                    
            }
        }
    }
}
