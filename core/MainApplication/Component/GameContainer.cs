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
using Services.ControlServices;
using core.Windows;
using Squid;
using MainApplication.Scenes;
using MainApplication.Windows;
using Services.WindowServices;

namespace MainApplication.Component
{
    public class GameContainer : Container
    {
        private Game game;

        private Player player;
        private Statistics statistics;
        private CameraStat cameraStat;
        private Landscape landscape;
        private Movement movement;
        private MouseEvent mouseEvent;
        private Desktop desktop;

        private Dictionary<String, Object> objects = new Dictionary<string, object>();

        private PlayerService playerService;
        private ItemService itemService;
        private CameraService cameraService;
        private ItemRepository itemRepository;
        private InputManager inputManager;
        private KeyBoard keyBoard;
        private CombatService combatService;
        private CombatRepository combatRepository;
        private ControlService controlService;
        private WindowService windowService;

        private Camera camera;

        private Dictionary<SceneName, Scene> scenes = new Dictionary<SceneName, Scene>();

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


            initScenes();
        }

        private void loadComponents()
        {
            foreach (var item in game.Components)
            {
                item.Load();
            }
            foreach (var item in scenes.Values)
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
            statistics.LookAtPoint = new MTV3D65.TV_3DVECTOR(100, 0, 200);
        }

        private void injectDependency()
        {
            camera.CameraStat = cameraStat;
            camera.CameraService = cameraService;
            inputManager.PlayerService = playerService;
            ((SimpleItemService)itemService).ItemRepository = itemRepository;
            (windowService as SimpleWindowService).InputManager = inputManager;
            player.PlayerService = playerService;
            mouseEvent.InputManager = inputManager;
            movement.InputManager = inputManager;
            movement.ControlService = controlService;
            movement.MouseEvent = mouseEvent;
            movement.WindowService = windowService;
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
            movement = new Movement(game);
            addComponent(movement);

            mouseEvent = new MouseEvent();
            
        }

        private void initScenes()
        {
            desktop = new MainDesktop(windowService);
            Scene scene = new GameScene(game, desktop);
            scenes.Add(SceneName.GAMESCENE, scene);
            addComponent(scene);

            initWindows();
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
            controlService = new SimpleControlService(statistics, landscape);
            windowService = new SimpleWindowService();
            
            registerObject("playerService", playerService);
            registerObject("itemRepository", itemRepository);
            registerObject("itemService", itemService);
            registerObject("cameraService", cameraService);
            registerObject("combatRepository", combatRepository);
            registerObject("combatService", combatService);
            registerObject("controlService", controlService);
            registerObject("windowService", windowService); 
        }

        private void initWindows()
        {
            windowService.addWindow(WindowsName.PLAYERSTAT, new PlayerStatisticsWindow(desktop));
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
