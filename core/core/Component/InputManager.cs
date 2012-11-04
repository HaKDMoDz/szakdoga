using System;
using MTV3D65;
using Squid;
using core;
using core.Service;
using core.input;
using core.Domain;

namespace core.Component
{
    public class InputManager : GameComponent
    {
        private int LastScroll;
        private TV_KEYDATA[] KeyBuffer;

        private bool rightMouseButton, leftMouseButton, dummy, middleMouseButton;
        private int mouseX, mouseY, mouseScroll;
        private int mAbsPosX, mAbsPosY;

        public bool MiddleMouseButton
        {
            get
            {
                return middleMouseButton;
            }
        }

        public bool RightMouseButton
        {
            get
            {
                return rightMouseButton;
            }
        }

        public bool LeftMouseButton
        {
            get
            {
                return leftMouseButton;
            }
        }

        public int MouseX
        {
            get
            {
                return mouseX;
            }
        }

        public int MouseY
        {
            get
            {
                return mouseY;
            }
        }

        public int MouseAbsX
        {
            get
            {
                return mAbsPosX;
            }
        }

        public int MouseAbsY
        {
            get
            {
                return mAbsPosY;
            }
        }

        public int Scroll
        {
            get
            {
                return mouseScroll;
            }
        }

        private PlayerService playerService;

        public PlayerService PlayerService
        {
            set
            {
                playerService = value;
            }
        }


        public InputManager(Game game)
            : base(game)
        {
            KeyBuffer = new TV_KEYDATA[0x100];
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Update(GameTime time)
        {
            bool[] buttons = new bool[4];
            int scroll = 0; int num = 0;

            Game.Input.GetAbsMouseState(ref mAbsPosX, ref mAbsPosY, ref buttons[0], ref buttons[1], ref buttons[2], ref buttons[3], ref scroll);

            int wheel = scroll > LastScroll ? -1 : (scroll < LastScroll ? 1 : 0);
            LastScroll = scroll;

            Game.Input.GetKeyBuffer(KeyBuffer, ref num);

            GUI.SetMouse(mAbsPosX, mAbsPosY, wheel);
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

            calculateCamera();
            checkCombatButtons();

            base.Update(time);
        }

        private void checkCombatButtons()
        {
            
            if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F1))
            {
                playerService.useSkill(CONST_TV_KEY.TV_KEY_F1);
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F2))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F3))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F4))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F5))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F6))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F7))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F8))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F9))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F10))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F11))
            {
            }
            else if (KeyBoard.KeyPressed(CONST_TV_KEY.TV_KEY_F12))
            {
            }
        }

        private void calculateCamera()
        {
            Game.Input.GetMouseState(ref mouseX, ref mouseY, ref leftMouseButton, ref rightMouseButton, ref middleMouseButton, ref dummy, ref mouseScroll);
       }
    }
}
