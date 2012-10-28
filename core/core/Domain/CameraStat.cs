using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;

namespace core.Domain
{
    public class CameraStat
    {
        private TV_3DVECTOR position;
        private TV_3DVECTOR lookAt;
        private float distance;
        private float angleX;
        private float angleY;

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

        public TV_3DVECTOR LookAt
        {
            get
            {
                return lookAt;
            }
            set
            {
                lookAt = value;
            }
        }

        public float Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        public float AngleX
        {
            get
            {
                return angleX;
            }
            set
            {
                angleX = value;
            }
        }

        public float AngleY
        {
            get
            {
                return angleY;
            }
            set
            {
                angleY = value;
            }
        }
   }
}
