using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Service
{
    public interface Container
    {
        void start();
        T getObject<T>(String name);
        void registerObject(String name, Object obj);
        void removeObject(String name);
        void addComponent(GameComponent component, String name);
    }
}
