using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using core.Component;
using MTV3D65;
using core.Service;

namespace MainApplication.Component.Cameras
{
    public class FollowCamera : GameComponent, CameraService
    {
        private TVCamera camera;

        public FollowCamera(Game game)
            : base(game)
        {

        }

        public override void Load()
        {
            camera = new TVCamera();
            setCamera(new TV_3DVECTOR(10, 10, 10), new TV_3DVECTOR(0, 0, 0));
            base.Load();
        }

        public void rotate()
        {
            throw new NotImplementedException();
        }

        private void setCamera(TV_3DVECTOR position, TV_3DVECTOR lookAt)
        {
            setPosition(position);
            setlookAt(lookAt);
        }

        private void setPosition(TV_3DVECTOR position)
        {
            camera.SetPosition(position.x, position.y, position.z);
        }

        private void setlookAt(TV_3DVECTOR lookAt)
        {
            camera.SetLookAt(lookAt.x, lookAt.y, lookAt.z);
        }

    }
}
