using System;
using System.Collections.Generic;
using core.Component;

namespace core.input
{
    public class MouseEvent
    {
        protected bool leftMouseButton, rightMouseButton, dummy, lastMouse, alreadyPress, firstClick, currentMouse;
        protected int mouseScroll, delay = 0;
        protected float repeatTime = 0;

        private InputManager inputManager;

        public InputManager InputManager
        {
            set
            {
                inputManager = value;
            }
        }

        public bool DoubleClick()
        {
            lastMouse = currentMouse;
            currentMouse = leftMouseButton;

            repeatTime += 0.5f;
            if (lastMouse != currentMouse)
            {
                if (firstClick && leftMouseButton && repeatTime < 300)
                {
                    repeatTime = 0;
                    firstClick = false;
                    return true;
                }
                else if (leftMouseButton)
                {
                    firstClick = true;
                }
            }
            if (repeatTime > 300)
            {
                repeatTime = 0;
                firstClick = false;
            }
            return false;
        }

        public bool Release()
        {
            lastMouse = currentMouse;
            if (leftMouseButton)
            {
                currentMouse = leftMouseButton;
            }
            else
            {
                currentMouse = false;
            }
            if (!currentMouse && lastMouse)
            {
                return true;
            }
            return false;
        }

        public bool Click()
        {

            if (inputManager.LeftMouseButton)
            {
                if (!firstClick)
                {
                    firstClick = true;
                    return true;
                }
            }
            else
            {
                firstClick = false;
            }
            return false;
        }

        public bool MouseDown()
        {
            if (leftMouseButton)
            {
                return true;
            }
            return false;
        }

        private bool DelayCounter()
        {
            if (delay < 5000)
                return true;
            else
            {
                delay = 0;
                alreadyPress = false;
                return false;
            }
        }
    }
}
