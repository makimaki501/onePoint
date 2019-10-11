using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MusicGame.Device;
using MusicGame.Actor;

namespace MusicGame.Scene
{
    class Title : IScene
    {
        private bool isEndFlag;
        private Map map;
        private GameObjectManager gameObjectManager;

        public Title()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();

            
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            map.Draw(renderer);
            gameObjectManager.Draw(renderer);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            gameObjectManager.Initialize();

            map = new Map(GameDevice.Instance());
            map.Load("Title.csv","./csv/");
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
            if (Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
            }
        }
    }
}
