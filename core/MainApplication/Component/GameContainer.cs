using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Component;
using core;
using core.Domain;
using core.Service;
using Services.PlayerServices;
using core.Repository;
using Services.ItemServices;
using Repositories.ItemRepositories;
using Services.CameraServices;
using core.input;
using Services.CombatServices;
using Repositories.CombatRepositories;
using Services.Attack;

namespace MainApplication.Component
{
    public class GameContainer : Container
    {
        private Game game;

        private Player player;
        private Statistics statistics;
        private CameraStat cameraStat;
        private Landscape landscape;

        private Dictionary<String, Object> objects = new Dictionary<string, object>();

        private PlayerService playerService;
        private ItemService itemService;
        private CameraService cameraService;
        private ItemRepository itemRepository;
        private InputManager inputManager;
        private KeyBoard keyBoard;
        private CombatService combatService;
        private CombatRepository combatRepository;


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
            inputManager.PlayerService = playerService;
            ((SimpleItemService)itemService).ItemRepository = itemRepository;
            player.PlayerService = playerService;
        }

        private void initComponent()
        {
            landscape = new Landscape(game);
            addComponent(landscape);
            camera = new Camera(game);
            addComponent(camera);
            addComponent(new SunLigth(game));
            inputManager = new InputManager(game);
            addComponent(inputManager);
            keyBoard = new KeyBoard(game);
            addComponent(keyBoard);
            player = new Player(game);            
            addComponent(player);
        }

        private void addComponent(GameComponent component)
        {
            game.Components.Add(component);
        }

        private void initServices()
        {
            combatRepository = new MemoryBaseCombatRepository();
            combatService = new SimpleCombatService(combatRepository);
            playerService = new SimplePlayerService(combatService, statistics, landscape);
                       
            itemRepository = new MemoryItemRepository();
            itemService = new SimpleItemService();
            cameraService = new FollowCameraService(cameraStat, inputManager, playerService);
            
            registerObject("playerService", playerService);
            registerObject("itemRepository", itemRepository);
            registerObject("itemService", itemService);
            registerObject("cameraService", cameraService);
            registerObject("combatRepository", combatRepository);
            registerObject("combatService", combatService);            
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
