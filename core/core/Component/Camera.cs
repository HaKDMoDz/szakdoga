using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using MTV3D65;
using core.Service;
using core.Domain;

namespace core.Component
{
    public class Camera : GameComponent
    {
        private TVCamera camera;

        private CameraStat cameraStat;

        private CameraService cameraService;

        public Camera(Game game)
            : base(game)
        {

        }

        public CameraStat CameraStat
        {
            set
            {
                cameraStat = value;
            }
        }

        public CameraService CameraService
        {
            set
            {
                cameraService = value;
            }
        }

        public override void Load()
        {            
            camera = new TVCamera();
            base.Load();
        }

        public override void Update(GameTime time)
        {
            cameraService.calcualteCameraStat();
            TV_3DVECTOR pos = cameraStat.Position;
            TV_3DVECTOR lookAt = cameraStat.LookAt;
            setCamera(pos, lookAt);
            base.Update(time);
        }

        public void setCamera(TV_3DVECTOR position, TV_3DVECTOR lookAt)
        {
            setPosition(position);
            setlookAt(lookAt);
        }

        public void setCamera(Vector3D position, Vector3D lookAt)
        {
            setPosition(position);
            setlookAt(lookAt);
        }

        public void setPosition(TV_3DVECTOR position)
        {
            setPosition(new Vector3D(position));
        }

        public void setPosition(Vector3D position)
        {
            camera.SetPosition(position.X, position.Y, position.Z);
        }

        public void setlookAt(TV_3DVECTOR lookAt)
        {
            setlookAt(new Vector3D(lookAt));
        }

        public void setlookAt(Vector3D lookAt)
        {
            camera.SetLookAt(lookAt.X, lookAt.Y, lookAt.Z);
        }

    }
}
