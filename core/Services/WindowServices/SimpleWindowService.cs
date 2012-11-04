using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;
using core.Windows;
using core.Service;
using core.Component;
using Squid;

namespace Services.WindowServices
{
    public class SimpleWindowService : WindowService
    {
        private Dictionary<WindowsName, WindowsBase> windows = new Dictionary<WindowsName, WindowsBase>();
        private InputManager inputManager;

        public InputManager InputManager
        {
            set
            {
                inputManager = value;
            }
        }

        public void addWindow(WindowsName windowName, WindowsBase window)
        {
            windows.Add(windowName, window);
        }

        public void removeWindow(WindowsName windowName)
        {
            windows.Remove(windowName);
        }

        public WindowsBase getWindow(WindowsName windowName)
        {
            return windows[windowName];
        }

        public void showWindow(WindowsName windowName)
        {
            windows[windowName].show();
        }

        public void closeWindow(WindowsName windowName)
        {
            windows[windowName].Close();
        }

        public bool clickInWindowArea()
        {
            bool ret = false;
            int i = 0;
            while (i < windows.Count && !ret)
            {
                ret = windows.Values.ElementAt(i).inWindow(new Point(inputManager.MouseAbsX, inputManager.MouseAbsY));
                i++;
            }


            return ret;
        }
    }
}
