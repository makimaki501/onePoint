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

            if (Input.GetKeyTrigger(Keys.D1))
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
                    player.SetDegree((float)Math.Atan2(player2.GetPosition().Y-player.GetPosition().Y, 
                        player2.GetPosition().X - player.GetPosition().X)-15-180);
                }
                if (player2.IsStop())
                {
                    player2.SetDegree((float)Math.Atan2(player.GetPosition().Y - player2.GetPosition().Y, 
                        player.GetPosition().X- player2.GetPosition().X)-15-180);
                    player2.SetPosition(player.GetPosition());
                }
            }

        }
    }
}
