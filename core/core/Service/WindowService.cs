using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Windows;
using core.Domain;

namespace core.Service
{
    public interface WindowService
    {
        void addWindow(WindowsName windowName, WindowsBase window);
        void removeWindow(WindowsName windowName);
        WindowsBase getWindow(WindowsName windowName);
        void showWindow(WindowsName windowName);
        void closeWindow(WindowsName windowName);
        bool clickInWindowArea();
    }
}
