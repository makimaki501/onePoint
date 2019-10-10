using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MusicGame.Device;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MusicGame.Actor
{
    class Player
    {
        private bool stop;
        private bool isDeadFlag;
        private Vector2 position;
        private float r = 128;//半径
        private float radian;
        private float degree ;
        private Vector2 Pos;
        private bool reset;

        public Player()
        {
            stop = true;
            isDeadFlag = false;
            position = new Vector2(600, 300);
            Pos = new Vector2(300,300);
            reset = false;
        }

        public void Initialize()
        {
            stop = true;
            isDeadFlag = false;
            position = new Vector2(600, 300);
            Pos = new Vector2(300, 300);
            reset = false;
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();

            renderer.DrawTexture("white", position);

            renderer.End();
        }

        public void Update(GameTime gameTime)
        {
            
            if (stop)
            {
                if (reset)
                {
                    radian = 0;
                    reset = false;
                }
                radian = degree * MathHelper.Pi / 360;
                degree += 12f;
                position.X = r * (float)Math.Cos(radian)+Pos.X;
                position.Y = r * (float)Math.Sin(radian)+Pos.Y;
            }

            if (Input.GetKeyState(Keys.Enter))
            {
                degree -= 11.9f;
            }

            if (Input.GetKeyTrigger(Keys.Space))
            {
                stop = !stop;
                reset = true; 
            }
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        
        public void SetPosition(Vector2 Pos)
        {
            this.Pos = Pos;
        }
        public void SetDegree(float radian)
        {
            this.radian =radian;
        }

        public float GetDegree()
        {
            return radian;
        }

        public bool IsStop()
        {
            return stop;
        }
    }
}
