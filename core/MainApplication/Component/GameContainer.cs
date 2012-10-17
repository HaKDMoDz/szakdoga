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

namespace MainApplication.Component
{
    class GameContainer : Container
    {
        private Game game;

        private Player player;

        private PlayerService playerService;

        public GameContainer(Game game)
        {
            this.game = game;
        }
        public void start()
        {
            addComponent(new Player(game));
            addComponent(new Rancor(game));
            addComponent(new SunLigth(game));
            addComponent(new FollowCamera(game));

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
            playerService.Player = player;
        }
    }
}
