using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Domain;
using core.Component;
using MTV3D65;
using core;

namespace Services.CameraServices
{
    public class FollowCameraService : CameraService
    {
        private CameraStat cameraStat;

        private InputManager inputManager;

        private PlayerService playerService;

        public FollowCameraService(CameraStat cameraStat, InputManager inputManager, PlayerService playerService)
        {
            this.cameraStat = cameraStat;
            this.inputManager = inputManager;
            this.playerService = playerService;
        }

        public CameraStat CameraStat
        {
            set
            {
                this.cameraStat = value;
            }
        }

        private void rotate()
        {
            if (inputManager.RightMouseButton)
            {
                cameraStat.AngleX += inputManager.MouseX / 15.0f;
                cameraStat.AngleY -= inputManager.MouseY / 15.0f;
            }
        }

        private void zoom()
        {
            if (cameraStat.Distance <= 8)
            {
                cameraStat.Distance = 9;
            }
            if (cameraStat.Distance > 50)
            {
                cameraStat.Distance = 50;
            }
            if (cameraStat.Distance <= 50 && cameraStat.Distance > 8)
            {
                cameraStat.Distance += inputManager.Scroll / 80f;
            }
        }

        private void calculate()
        {
            TV_3DVECTOR oldCameraPos = cameraStat.Position;
            TV_3DVECTOR cameraPosNew = Game.Math.MoveAroundPoint(cameraStat.LookAt, cameraStat.Distance, cameraStat.AngleX, cameraStat.AngleY);


            //if (GlobalMethods.Distance(cameraPosNew,
            //    new TV_3DVECTOR(cameraPosNew.x, Landscape.GetHeight(cameraPosNew.x, cameraPosNew.z), cameraPosNew.z)) > 2 &&
            //    cameraPosNew.y > Landscape.GetHeight(cameraPosNew.x, cameraPosNew.z))
            {
                cameraStat.Position = cameraPosNew;
            }
        }

        public CameraStat calcualteCameraStat()
        {
            cameraStat.LookAt = playerService.getPosition();
            rotate();
            zoom();
            calculate();

            return cameraStat;
        }
    }
}
