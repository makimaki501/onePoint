using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MusicGame.Device;
using MusicGame.Actor;
using MusicGame.Def;

namespace MusicGame.Scene
{
    class Title : IScene
    {
        private bool isEndFlag;
        private Map map;
        private Player player;
        private GameObjectManager gameObjectManager;

        public Title()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();
            player = new Player(new Vector2(Screen.Width / 2, Screen.Height / 2));
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            map.Draw(renderer);
            gameObjectManager.Draw(renderer);
            player.Draw(renderer);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            gameObjectManager.Initialize();
            player.Initialize();

            map = new Map(GameDevice.Instance());
            map.Load("Title128.csv", "./csv/");
            gameObjectManager.Add(map);

        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.Select;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            gameObjectManager.Update(gameTime);
            map.Update(gameTime);
            player.Update(gameTime);
            //if (Input.GetKeyTrigger(Keys.Space))
            //{
            //    if (player.IsStop())
            //    {
            //        player.SetPos(player.GetPosition2());
            //        player.SetRadian((float)Math.Atan2(player.GetPosition2().Y - player.GetPosition().Y,
            //            player.GetPosition2().X - player.GetPosition().X));
            //    }
            //    else
            //    {
            //        player.SetPos(player.GetPosition());
            //        player.SetRadian((float)Math.Atan2(player.GetPosition().Y - player.GetPosition2().Y,
            //            player.GetPosition().X - player.GetPosition2().X));
            //    }
            //}
            if (Input.GetKeyTrigger(Keys.D1))
            {
                isEndFlag = true;
            }
        }
    }
}
