using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service
{
    public interface CameraService
    {
        //void rotate(float cameraAngleX, float cameraAngleY);
        //void zoom(float cameraDistance);
        CameraStat calcualteCameraStat();
    }
}
