using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;

namespace core.Domain
{
    public class Vector3D
    {
        private float x, y, z;

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public float Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3D(TV_3DVECTOR vector)
            : this(vector.x, vector.y, vector.z)
        {

        }

        public bool isEmpty()
        {
            return (x == y && x == z && x == 0);
        }

        public void clear()
        {
            x = y = z = 0;
        }
    }
}
