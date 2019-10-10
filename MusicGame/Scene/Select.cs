﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MusicGame.Device;

namespace MusicGame.Scene
{
    class Select : IScene
    {
        private bool isEndFlag;
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("persona1", Vector2.Zero);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.GamePlay;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
            }
        }
    }
}
