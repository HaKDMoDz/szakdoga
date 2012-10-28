using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Component;
using core;
using MainApplication.Component.Land;
using MainApplication.Component.Characters;
using core.Domain;
using core.Service;
using Services.PlayerServices;
using core.Repository;
using Services.ItemServices;
using Repositories.ItemRepositories;
using Services.CameraServices;

namespace MainApplication.Component
{
    public class GameContainer : Container
    {
        private Game game;

        private Player player;
        private Statistics statistics;
        private CameraStat cameraStat;

        private Dictionary<String, Object> objects = new Dictionary<string, object>();

        private PlayerService playerService;
        private ItemService itemService;
        private CameraService cameraService;
        private ItemRepository itemRepository;
        private InputManager inputManager;


        private Camera camera;

        public GameContainer(Game game)
        {
            this.game = game;
        }
        public void start()
        {
            initComponent();
            initDomain();            
            initServices();
            injectDependency();
            loadComponents();
        }

        private void loadComponents()
        {
            foreach (var item in game.Components)
            {
                item.Load();
            }
        }

        private void initDomain()
        {
            cameraStat = new CameraStat();
            cameraStat.Distance = 20;
            cameraStat.AngleX = 180;
            cameraStat.AngleY = -30;

            statistics = new Statistics();
            statistics.HealthPoint = 100;
            statistics.IsDead = false;
            statistics.MaxHealthPoint = 100;
        }

        private void injectDependency()
        {
            camera.CameraStat = cameraStat;
            camera.CameraService = cameraService;
        }

        private void initComponent()
        {
            camera = new Camera(game);
            addComponent(camera);
            addComponent(new Rancor(game));
            addComponent(new SunLigth(game));
            inputManager = new InputManager(game);
            addComponent(inputManager);
        }

        private void addComponent(GameComponent component)
        {
            game.Components.Add(component);
        }

        private void initServices()
        {
            playerService = new SimplePlayerService();
            ((SimplePlayerService)playerService).Statistics = statistics;

            itemRepository = new MemoryItemRepository();

            itemService = new SimpleItemService();
            ((SimpleItemService)itemService).ItemRepository = itemRepository;

            cameraService = new FollowCameraService(cameraStat, inputManager);


            registerObject("playerService", playerService);
            registerObject("itemRepository", itemRepository);
            registerObject("itemService", itemService);
            registerObject("cameraService", cameraService);
            
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
