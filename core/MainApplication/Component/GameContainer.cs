using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Component;
using core;
using MainApplication.Component.Land;
using MainApplication.Component.Characters;
using MainApplication.Component.Cameras;
using core.Domain;
using core.Service;
using Services.PlayerServices;
using core.Repository;
using Repositories.MemoryBaseRepository;
using Services.ItemServices;

namespace MainApplication.Component
{
    public class GameContainer : Container
    {
        private Game game;

        private Player player;

        private Dictionary<String, Object> objects = new Dictionary<string, object>();

        private PlayerService playerService;
        private ItemService itemService;
        private ItemRepository itemRepository;

        public GameContainer(Game game)
        {
            this.game = game;
        }
        public void start()
        {
            //addComponent(new Player(game));
            //addComponent(new Rancor(game));
            //addComponent(new SunLigth(game));
            //addComponent(new FollowCamera(game));

            initServices();
        }

        private void addComponent(GameComponent component)
        {
            game.Components.Add(component);
            component.Load();
        }

        private void initServices()
        {
            playerService = new SimplePlayerService();
            ((SimplePlayerService)playerService).Statistics = player;

            itemRepository = new MemoryItemRepository();

            itemService = new SimpleItemService();
            ((SimpleItemService)itemService).ItemRepository = itemRepository;


            registerObject("playerService", playerService);
            registerObject("itemRepository", itemRepository);
            registerObject("itemService", itemService);
            
        }

        public T getObject<T>(string name)
        {
            Object obj = objects[name];

            if (obj != null && obj is T)
            {
                T ret = (T)obj;
                return ret;
            }
            else
            {
                throw new ArgumentException("Not valid type!");
            }            
        }

        public void registerObject(String name, object obj)
        {
            objects.Add(name, obj);
        }

        public void removeObject(String name)
        {
            objects.Remove(name);
        }
    }
}
