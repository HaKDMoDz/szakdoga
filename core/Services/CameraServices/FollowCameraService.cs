using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;

namespace Services.CameraServices
{
    public class FollowCameraService : CameraService
    {
        private Camera camera;

        public FollowCameraService(Camera camera)
        {
            this.camera = camera;
        }

        public Camera Camera
        {
            set
            {
                this.camera = value;
            }
        }

        public void rotate(float cameraAngleX, float cameraAngleY)
        {
            if (InputManager.RightMouseButton)
            {
                InputManager.CameraAngleX += InputManager.MouseX / 15.0f;
                InputManager.CameraAngleY -= InputManager.MouseY / 15.0f;
            }

            

            Rotate(InputManager.CameraDistance, InputManager.CameraAngleX, InputManager.CameraAngleY);
        }

        public void zoom(float cameraDistance, float scroll)
        {
            if (cameraDistance <= 8)
            {
                cameraDistance = 9;
            }
            if (cameraDistance > 50)
            {
                cameraDistance = 50;
            }
            if (cameraDistance <= 50 && cameraDistance > 8)
            {
                cameraDistance += scroll / 80f;
            }
        }
    }
}
