using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public class MouseStatistics
    {
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

        public float MouseX
        {
            get
            {
                return mouseX;
            }
        }

        public float MouseY
        {
            get
            {
                return mouseY;
            }
        }

        public float Scroll
        {
            get
            {
                return mouseScroll;
            }
        }
    }
}
