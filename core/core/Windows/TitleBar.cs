using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Squid;

namespace core.Windows
{
    public class TitleBar : Label
    {
        public Button Button { get; private set; }

        protected override void Initialize()
        {
            Button = new Button();
            Button.Size = new Point(20, 20);
            Button.Style = "close";
            Button.Tooltip = "Close Window";
            Button.Dock = DockStyle.Right;
            Button.Margin = new Margin(0, 8, 8, 8);
            Elements.Add(Button);
        }
    }
}
