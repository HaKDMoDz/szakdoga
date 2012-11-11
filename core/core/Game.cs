using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;
using System.Windows.Forms;

namespace core
{
    public class Game : IDisposable
    {

        #region fields

        protected GameTime Time = new GameTime();
        protected bool inFocus = true;

        //protected LoaderScreen loaderScreen;

        #endregion

        #region static properties

        public static float ElapsedSeconds { get; private set; }
        public static float ElapsedMilliseconds { get; private set; }
        public static Random Random { get; private set; }
        public static TVEngine Engine { get; private set; }
        public static TVScene Scene { get; private set; }
        public static TVScreen2DImmediate Screen2D { get; private set; }
        public static TVTextureFactory Textures { get; private set; }
        public static TVScreen2DText Text2D { get; private set; }
        public static TVGlobals Globals { get; private set; }
        public static TVMaterialFactory Materials { get; private set; }
        public static TVMathLibrary Math { get; private set; }
        public static TVGraphicEffect Effects { get; private set; }
        public static TVAtmosphere Atmosphere { get; private set; }
        public static TVInternalObjects Internal { get; private set; }
        public static TVLightEngine Light { get; private set; }
        public static TVInputEngine Input { get; private set; }

        #endregion

        #region public properties

        public bool Active { get; private set; }
        public bool Running { get; private set; }
        public System.Windows.Forms.Form Form { get; private set; }
        public List<GameComponent> Components { get; private set; }

        #endregion

        #region ctor

        public Game()
        {
            Form = new Form();
            Form.Activated += Window_Activated;
            Form.Deactivate += Window_Deactivate;
        }

        #endregion

        #region public methods

        public void Run()
        {
            if (Running) return;

            Running = true;

            //loaderScreen = new LoaderScreen();
            //loaderScreen.Visible = true;

            StartEngine();
            Initialize();
            Load();

            //loaderScreen.Close();

            Application.Idle += Application_Idle;
            Application.Run(Form);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region private methods

        private void StartEngine()
        {
            Time = new GameTime();
            Components = new List<GameComponent>();

            Engine = new TVEngine();
            Scene = new TVScene();
            Screen2D = new TVScreen2DImmediate();
            Textures = new TVTextureFactory();
            Text2D = new TVScreen2DText();
            Globals = new TVGlobals();
            Materials = new TVMaterialFactory();
            Math = new TVMathLibrary();
            Effects = new TVGraphicEffect();
            Atmosphere = new TVAtmosphere();
            Internal = new TVInternalObjects();
            Light = new TVLightEngine();
            Input = new TVInputEngine();
            Random = new Random();

            Engine.SetInternalShaderVersion(CONST_TV_SHADERMODEL.TV_SHADERMODEL_BEST);
            Engine.SetAngleSystem(CONST_TV_ANGLE.TV_ANGLE_DEGREE);
            Engine.AllowMultithreading(true);
            Engine.SetFPUPrecision(true);
            Engine.EnableSmoothTime(false);
            Engine.SetDebugMode(true, true);
            Engine.SetDebugFile("debug.txt");
            Engine.EnableProfiler(false);
            Engine.DisplayFPS(false);
            Engine.SetVSync(false);
            Engine.SetAntialiasing(false, CONST_TV_MULTISAMPLE_TYPE.TV_MULTISAMPLE_NONE);


            Engine.Init3DWindowed(Form.Handle);
            //Engine.Init3DFullscreen(1920, 1200, 32, true, false, CONST_TV_DEPTHBUFFERFORMAT.TV_DEPTHBUFFER_BESTBUFFER, 1, Window.Handle);
            Engine.GetViewport().SetAutoResize(true);

            Input.Initialize(true, true);
            Input.SetRepetitionDelay(400, 100);

            Textures.SetTextureMode(CONST_TV_TEXTUREMODE.TV_TEXTUREMODE_BETTER);
            Light.SetGlobalAmbient(0, 0, 0);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (NativeMethods.AppStillIdle)
            {
                if (Running)
                    Tick();
            }
        }

        private void Window_Deactivate(object sender, EventArgs e)
        {
            Active = false;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Active = true;
        }

        private void Tick()
        {
            Update(Time);

            Engine.Clear();

            Draw(Time);

            Engine.RenderToScreen();

            Time.Update(Engine.AccurateTimeElapsed());
            ElapsedMilliseconds = Time.ElapsedMilliseconds;
            ElapsedSeconds = Time.ElapsedSeconds;
        }

        private void Dispose(bool disposed)
        {
            Unload();
        }

        private void LoadScene()
        {

        }

        #endregion

        #region virtual methods

        protected virtual void Initialize() { }

        protected virtual void Load()
        {
            int i = 0;

            foreach (GameComponent component in Components)
            {
                component.Load();
                i++;
            }
        }

        protected virtual void Unload() { }

        protected virtual void Update(GameTime time)
        {
            Form.LostFocus += new EventHandler(Form_LostFocus);
            Form.GotFocus += new EventHandler(Form_GotFocus);

            if (inFocus)
            {
                foreach (GameComponent component in Components)
                    component.Update(time);
            }
        }

        void Form_GotFocus(object sender, EventArgs e)
        {
            inFocus = true;
        }

        void Form_LostFocus(object sender, EventArgs e)
        {
            inFocus = false;
        }

        protected virtual void Draw(GameTime time)
        {
            foreach (GameComponent component in Components)
            {
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Draw(time);
                }
            }
        }

        #endregion

       
    }
}
