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
    class GamePlay : IScene
    {
        private bool isEndFlag;
        private Player player;
        private Player2 player2;

        public GamePlay()
        {
            isEndFlag = false;
            player = new Player();
            player2 = new Player2();
        }
        public void Draw(Renderer renderer)
        {
            player.Draw(renderer);
            player2.Draw(renderer);
            renderer.Begin();
            renderer.DrawTexture("white", Vector2.Zero);
            renderer.End();

        }

        public void Initialize()
        {
            isEndFlag = false;
            player.Initialize();
            player2.Initialize();
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.Title;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            player2.Update(gameTime);
            Position();

            if (Input.GetKeyTrigger(Keys.Enter))
            {
                isEndFlag = true;
            }
        }

        private void Position()
        {
            if (Input.GetKeyTrigger(Keys.Space))
            {
                if (player.IsStop())
                {
                    player.SetPosition(player2.GetPosition());
                    player.SetDegree(player2.GetDegree()-player.GetDegree());
                }
                if (player2.IsStop())
                {
                    player2.SetDegree(player.GetDegree()-player2.GetDegree());
                    player2.SetPosition(player.GetPosition());
                }
            }

        }
    }
}
