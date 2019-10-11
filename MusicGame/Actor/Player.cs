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
        private Vector2 position, position2;
        private float r = 128;//半径
        private float radian;
        private float addRadian;
        private Vector2 Pos;
        private bool reset;

        public Player(Vector2 position)
        {
            this.Pos = position;
            stop = true;
            isDeadFlag = false;
            reset = false;
        }

        public void Initialize()
        {
            stop = true;
            isDeadFlag = false;
            reset = false;
            addRadian = 0.1f;
            radian = 1;
        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("white", position);
            renderer.DrawTexture("black", position2);
        }

        public void Update(GameTime gameTime)
        {

            if (stop)
            {
                if (reset)
                {
                    SetRadian((float)Math.Atan2(GetPosition2().Y - GetPosition().Y,
                        GetPosition2().X - GetPosition().X) + MathHelper.Pi);
                    SetPos(GetPosition2());
                    reset = false;
                }
                radian -= addRadian;
                position.X = r * (float)Math.Cos(radian) + Pos.X;
                position.Y = r * (float)Math.Sin(radian) + Pos.Y;
            }
            else
            {
                if (reset)
                {
                    SetRadian((float)Math.Atan2(GetPosition().Y - GetPosition2().Y,
                        GetPosition().X - GetPosition2().X) + MathHelper.Pi);
                    SetPos(GetPosition());
                    reset = false;
                }
                radian -= addRadian;
                position2.X = r * (float)Math.Cos(radian) + Pos.X;
                position2.Y = r * (float)Math.Sin(radian) + Pos.Y;
            }


            if (Input.GetKeyState(Keys.Enter))
            {
                radian += 0.095f;
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
        public Vector2 GetPosition2()
        {
            return position2;
        }

        public void SetPos(Vector2 Pos)
        {
            this.Pos = Pos;
        }

        public float GetRadian()
        {
            return radian;
        }
        public float GetDegree()
        {
            float degree = radian / 2 * MathHelper.Pi * 360;
            return degree;
        }
        public void SetRadian(float radian)
        {
            this.radian = radian;
        }
        public void SetDegree(float degree)
        {

            this.radian = degree / 360 * 2 * MathHelper.Pi;
        }
        public bool IsStop()
        {
            return stop;
        }
    }
}
