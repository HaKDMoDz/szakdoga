using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MTV3D65;
using Squid;

namespace core
{
    public class RenderOpt : ISquidRenderer
    {
        [DllImport("user32.dll")]
        private static extern int GetKeyboardLayout(int dwLayout);
        [DllImport("user32.dll")]
        private static extern int GetKeyboardState(ref byte pbKeyState);
        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyEx")]
        private static extern int MapVirtualKeyExA(int uCode, int uMapType, int dwhkl);
        [DllImport("user32.dll")]
        private static extern int ToAsciiEx(int uVirtKey, int uScanCode, ref byte lpKeyState, ref short lpChar, int uFlags, int dwhkl);

        private Dictionary<string, int> Fonts = new Dictionary<string, int>();
        private Dictionary<string, int> Textures = new Dictionary<string, int>();
        private Dictionary<string, Font> FontTypes = new Dictionary<string, Font>();

        private int KeyboardLayout;
        private byte[] KeyStates;

        public RenderOpt()
        {
            FontTypes.Add(Font.Default, new Font { Name = Font.Default, Family = "Arial", Size = 8, Bold = true, International = true });
            FontTypes.Add("arial10", new Font { Name = "arial10", Family = "Arial", Size = 10, Bold = true, International = true });
            FontTypes.Add("times10", new Font { Name = "times10", Family = "Times New Roman", Size = 10, Bold = true, International = true });
            KeyboardLayout = GetKeyboardLayout(0);
            KeyStates = new byte[0x100];
        }

        public bool TranslateKey(int code, ref char character)
        {
            short lpChar = 0;
            if (GetKeyboardState(ref KeyStates[0]) == 0)
                return false;

            int result = ToAsciiEx(MapVirtualKeyExA(code, 1, KeyboardLayout), code, ref KeyStates[0], ref lpChar, 0, KeyboardLayout);
            if (result == 1)
            {
                character = (char)((ushort)lpChar);
                return true;
            }

            return false;
        }

        public int GetTexture(string name)
        {
            if (Textures.ContainsKey(name))
                return Textures[name];

            int texture = Game.Textures.LoadTexture(name, name, -1, -1, MTV3D65.CONST_TV_COLORKEY.TV_COLORKEY_USE_ALPHA_CHANNEL, false);

            // if texture is not 2^n
            // delete and reload with correct size to avoid stretching
            TV_TEXTURE info = Game.Textures.GetTextureInfo(texture);
            if (!info.RealWidth.IsPowerOfTwo() || !info.RealHeight.IsPowerOfTwo())
            {
                Game.Textures.DeleteTexture(texture);
                texture = Game.Textures.LoadTexture(name, name, info.RealWidth, info.RealHeight, MTV3D65.CONST_TV_COLORKEY.TV_COLORKEY_USE_ALPHA_CHANNEL, false);
            }

            if (texture > 0)
                Textures.Add(name, texture);

            return texture;
        }

        public int GetFont(string name)
        {
            if (Fonts.ContainsKey(name))
                return Fonts[name];

            if (FontTypes.ContainsKey(name))
            {
                Font font = FontTypes[name];
                int index = Game.Text2D.TextureFont_Create(font.Name, font.Family, font.Size, font.Bold, font.Underlined, font.Italic, font.International, true);
                Fonts.Add(name, index);
                return index;
            }

            return -1;
        }

        public Squid.Point GetTextSize(string text, int font)
        {
            float x = 0;
            float y = 0;

            Game.Text2D.TextureFont_GetTextSize(text, font, ref x, ref y);
            return new Squid.Point { x = (int)x, y = (int)y };
        }

        public Squid.Point GetTextureSize(int texture)
        {
            TV_TEXTURE info = Game.Textures.GetTextureInfo(texture);
            return new Squid.Point(info.RealWidth, info.RealHeight);
        }

        public void DrawBox(int x, int y, int w, int h, int color)
        {
            Game.Screen2D.Draw_FilledBox(x, y, x + w - 1, y + h - 1, color);
        }

        public void DrawText(string text, int x, int y, int font, int color)
        {
            Game.Text2D.TextureFont_DrawText(text, x, y, color, font);
        }

        public void DrawTexture(int texture, int x, int y, int w, int h, UVCoords uv, int color)
        {
            Game.Screen2D.Draw_Texture(texture, x, y, x + w - 1, y + h - 1, color, color, color, color, uv.U1, uv.V1, uv.U2, uv.V2);
        }

        public void Scissor(int x1, int y1, int x2, int y2)
        {
            Game.Engine.GetViewport().SetTargetArea(x1, y1, x2 - x1, y2 - y1);
        }

        public void StartBatch()
        {
            Game.Text2D.Action_BeginText(true);
        }

        public void EndBatch()
        {
            Game.Text2D.Action_EndText();
        }

        public void Dispose() { }
    }

    public static class Extensions
    {
        public static bool IsPowerOfTwo(this int n)
        {
            return ((n != 0) && (n & (n - 1)) == 0);
        }
    }
}
