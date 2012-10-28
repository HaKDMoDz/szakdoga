using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.input
{

    public class KeyBoard : GameComponent
    {
        private static MTV3D65.CONST_TV_KEY _lastKey, _currentKey;

        public override void Update(GameTime time)
        {
            base.Update(time);

            _lastKey = _currentKey;
            _currentKey = KeyBoard.GetPressedKey();
        }

        public KeyBoard(Game game) : base(game) { }

        public static bool KeyPressed(MTV3D65.CONST_TV_KEY key)
        {
            return (_lastKey != _currentKey && Game.Input.IsKeyPressed(key));            
        }


        private static MTV3D65.CONST_TV_KEY GetPressedKey()
        {
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_ESCAPE))
                return MTV3D65.CONST_TV_KEY.TV_KEY_ESCAPE;


            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F1))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F1;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F2))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F2;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F3))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F3;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F4))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F4;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F5))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F5;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F6))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F6;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F7))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F7;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F8))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F8;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F9))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F9;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F10))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F10;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F11))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F11;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F12))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F12;

            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_1))
                return MTV3D65.CONST_TV_KEY.TV_KEY_1;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_2))
                return MTV3D65.CONST_TV_KEY.TV_KEY_2;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_3))
                return MTV3D65.CONST_TV_KEY.TV_KEY_3;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_4))
                return MTV3D65.CONST_TV_KEY.TV_KEY_4;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_5))
                return MTV3D65.CONST_TV_KEY.TV_KEY_5;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_6))
                return MTV3D65.CONST_TV_KEY.TV_KEY_6;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_7))
                return MTV3D65.CONST_TV_KEY.TV_KEY_7;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_8))
                return MTV3D65.CONST_TV_KEY.TV_KEY_8;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_9))
                return MTV3D65.CONST_TV_KEY.TV_KEY_9;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_0))
                return MTV3D65.CONST_TV_KEY.TV_KEY_0;

            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_A))
                return MTV3D65.CONST_TV_KEY.TV_KEY_A;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_B))
                return MTV3D65.CONST_TV_KEY.TV_KEY_B;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_C))
                return MTV3D65.CONST_TV_KEY.TV_KEY_C;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_D))
                return MTV3D65.CONST_TV_KEY.TV_KEY_D;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_E))
                return MTV3D65.CONST_TV_KEY.TV_KEY_E;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_F))
                return MTV3D65.CONST_TV_KEY.TV_KEY_F;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_G))
                return MTV3D65.CONST_TV_KEY.TV_KEY_G;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_H))
                return MTV3D65.CONST_TV_KEY.TV_KEY_H;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_I))
                return MTV3D65.CONST_TV_KEY.TV_KEY_I;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_J))
                return MTV3D65.CONST_TV_KEY.TV_KEY_J;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_K))
                return MTV3D65.CONST_TV_KEY.TV_KEY_K;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_L))
                return MTV3D65.CONST_TV_KEY.TV_KEY_L;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_M))
                return MTV3D65.CONST_TV_KEY.TV_KEY_M;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_N))
                return MTV3D65.CONST_TV_KEY.TV_KEY_N;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_O))
                return MTV3D65.CONST_TV_KEY.TV_KEY_O;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_P))
                return MTV3D65.CONST_TV_KEY.TV_KEY_P;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_Q))
                return MTV3D65.CONST_TV_KEY.TV_KEY_Q;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_R))
                return MTV3D65.CONST_TV_KEY.TV_KEY_R;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_S))
                return MTV3D65.CONST_TV_KEY.TV_KEY_S;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_T))
                return MTV3D65.CONST_TV_KEY.TV_KEY_T;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_U))
                return MTV3D65.CONST_TV_KEY.TV_KEY_U;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_V))
                return MTV3D65.CONST_TV_KEY.TV_KEY_V;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_W))
                return MTV3D65.CONST_TV_KEY.TV_KEY_W;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_X))
                return MTV3D65.CONST_TV_KEY.TV_KEY_X;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_Y))
                return MTV3D65.CONST_TV_KEY.TV_KEY_Y;
            if (Game.Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_Z))
                return MTV3D65.CONST_TV_KEY.TV_KEY_Z;
            return MTV3D65.CONST_TV_KEY.TV_KEY_NOCONVERT;
        }
    }
}

