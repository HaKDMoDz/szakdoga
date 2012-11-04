using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Squid;

namespace core.Windows
{
    public abstract class WindowsBase : Window
    {
        private TitleBar titlebar;
        private Desktop desktop;

        public WindowsBase(Desktop desktop)
        {
            this.desktop = desktop;
        }

        protected override void Initialize()
        {
            base.Initialize();

            AllowDragOut = true;
            Padding = new Margin();

            titlebar = new TitleBar();
            titlebar.Dock = DockStyle.Top;
            titlebar.Size = new Squid.Point(122, 35);
            titlebar.OnMouseDown += delegate(Control sender) { StartDrag(); };
            titlebar.OnMouseUp += delegate(Control sender) { StopDrag(); };
            titlebar.Cursor = Cursors.Move;
            titlebar.Style = "header";
            titlebar.Margin = new Margin(0, 0, 0, -1);
            titlebar.Button.OnMouseClick += Button_Close;

            Controls.Add(titlebar);

            initializeComponent();
        }

        public virtual void initializeComponent()
        {
        }
        
        private void Button_Close(Control sender)
        {
            this.Close();
        }

        public void show()
        {
            this.Show(desktop);
        }

        protected void setWindowTitle(String title)
        {
            titlebar.Text = title;
        }

        public bool inWindow(Point point)
        {
            return (Position.x < point.x && point.x < Position.x + Size.x &&
                    Position.y < point.y && point.y < Position.y + Size.y);
        }
    }

}
