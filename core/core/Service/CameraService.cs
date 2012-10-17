using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Service
{
    public interface CameraService
    {
        void rotate(float cameraAngleX, float cameraAngleY);
        void zoom(float cameraDistance);
    }
}
