using System;
using MTV3D65;
using Squid;
using core;
using core.Service;

namespace GameClient
{
    public class InputManager : GameComponent
    {
        private int LastScroll;
        private TV_KEYDATA[] KeyBuffer;

        private CameraService cameraService;

        public InputManager(Game game)
            : base(game)
        {
            KeyBuffer = new TV_KEYDATA[0x100];
        }

        public override void Load()
        {
            base.Load();
            CameraDistance = 20;
            CameraAngleX = 180;
            CameraAngleY = -30;
        }

        public override void Update(GameTime time)
        {
            bool[] buttons = new bool[4];
            int mx = 0; int my = 0; int scroll = 0; int num = 0;

            Game.Input.GetAbsMouseState(ref mx, ref my, ref buttons[0], ref buttons[1], ref buttons[2], ref buttons[3], ref scroll);

            int wheel = scroll > LastScroll ? -1 : (scroll < LastScroll ? 1 : 0);
            LastScroll = scroll;

            Game.Input.GetKeyBuffer(KeyBuffer, ref num);

            GUI.SetMouse(mx, my, wheel);
            GUI.SetButtons(buttons);

            KeyData[] keys = new KeyData[num];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].Scancode = KeyBuffer[i].Key;
                keys[i].Pressed = KeyBuffer[i].Pressed != 0;
                keys[i].Released = KeyBuffer[i].Released != 0;
            }

            GUI.SetKeyboard(keys);
            GUI.TimeElapsed = time.ElapsedMilliseconds;

            cameraService.zoom(scroll);
            cameraService.rotate(scroll);

            base.Update(time);
        }

        private void calculateCamera()
        {
            Game.Input.GetMouseState(ref MouseX, ref MouseY, ref LeftMouseButton, ref RightMouseButton, ref MiddleMouseButton, ref Dummy, ref MouseScroll);
            
        }
    }
}
