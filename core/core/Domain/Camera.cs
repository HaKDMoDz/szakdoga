using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using MTV3D65;
using core.Service;

namespace core.Domain
{
    public class Camera : GameComponent
    {
        private TVCamera camera;

        public Camera(Game game)
            : base(game)
        {

        }

        public override void Load()
        {
            camera = new TVCamera();
            setCamera(new TV_3DVECTOR(10, 10, 10), new TV_3DVECTOR(0, 0, 0));
            base.Load();
        }
        
        private void setCamera(TV_3DVECTOR position, TV_3DVECTOR lookAt)
        {
            setPosition(position);
            setlookAt(lookAt);
        }

        private void setCamera(Vector3D position, Vector3D lookAt)
        {
            setPosition(position);
            setlookAt(lookAt);
        }

        private void setPosition(TV_3DVECTOR position)
        {
            setPosition(new Vector3D(position));
        }

        private void setPosition(Vector3D position)
        {
            camera.SetPosition(position.X, position.Y, position.Z);
        }

        private void setlookAt(TV_3DVECTOR lookAt)
        {
            setlookAt(new Vector3D(lookAt));
        }

        private void setlookAt(Vector3D lookAt)
        {
            camera.SetLookAt(lookAt.X, lookAt.Y, lookAt.Z);
        }

    }
}
