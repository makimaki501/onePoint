using Microsoft.Xna.Framework;
using MusicGame.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame.Actor.Effect
{
    class ParticleManager
    {
        //パーティクルのリスト
        private List<Particle> particles = new List<Particle>();
        private Particle p;
        public string name;


        public ParticleManager()
        {
           
        }

        public void Clear()
        {
            particles.Clear();

        }

        public void Update(float delta)
        {
            //一括更新
            foreach (var p in particles)
            {
                p.Update(delta);
            }

            //死亡しているものはリストから削除
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i].IsDead())
                {
                    particles.Remove(particles[i]);
                }
            }

        }

        public void Shutdown()
        {
            Clear();
        }

        public void Draw(Renderer renderer)
        {
            //一括描画
            foreach (var p in particles)
            {
                p.Draw(renderer);
            }

        }

        public void Circle(string name, Vector2 position, int minAngle, int maxAangle, float scale, float shrinkRate, float duration, float alpha, float alphaAmount, int amount, int maxSpeed, Color color)
        {
            var rnd = GameDevice.Instance().GetRandom();

            this.name = name;
            for (int i = 0; i < amount; i++)
            {
                int angle = rnd.Next(minAngle, maxAangle);//ランダムな角度取得

                float speed = rnd.Next(1, maxSpeed);//ランダムな速度取得

                //新しいパーティクルを作る
                p = new Particle(name, position, speed, angle, scale, shrinkRate, duration, alpha, alphaAmount, color);

                //パーティクルを足す
                particles.Add(p);
            }
        }

        public void Circle2(string name, Vector2 position, int minAngle, int maxAangle, float scale, float shrinkRate, float duration, float alpha, float alphaAmount, int amount, int maxSpeed, Color color)
        {
            var rnd = GameDevice.Instance().GetRandom();

            this.name = name;
            for (int i = 0; i < amount; i++)
            {
                int angle = rnd.Next(minAngle, maxAangle);//ランダムな角度取得

                float speed = maxSpeed;//ランダムな速度取得


                //新しいパーティクルを作る
                p = new Particle(name, position, speed, angle, scale, shrinkRate, duration, alpha, alphaAmount, color);

                //パーティクルを足す
                particles.Add(p);
            }
        }

     

        public void Down(float shrinkRate, float duration, float alpha, float alphaAmount, int amount, int maxSpeed, Color color)
        {
            var rnd = GameDevice.Instance().GetRandom();


            for (int i = 0; i < amount; i++)
            {
                int number = rnd.Next(50);

                if (number <= 25)
                {
                    name = "traiangle3";

                    float angle = 180;
                    float scale = rnd.Next(1, 4);
                    float speed = rnd.Next(10, maxSpeed);
                    Vector2 position = new Vector2(rnd.Next(1920), rnd.Next(1080));

                    //新しいパーティクルを作る
                    p = new Particle(name, position, speed, angle, scale, shrinkRate, duration, alpha, alphaAmount, color);

                    particles.Add(p);
                }

                else if (number >= 26)
                {
                    name = "traiangle4";

                    float angle = 180;
                    float scale = rnd.Next(1, 4);
                    float speed = rnd.Next(10, maxSpeed);
                    Vector2 position = new Vector2(rnd.Next(1920), rnd.Next(1080));

                    //新しいパーティクルを作る
                    p = new Particle(name, position, speed, angle, scale, shrinkRate, duration, alpha, alphaAmount, color);

                    particles.Add(p);
                }


            }
        }

        public void TitleDown(float shrinkRate, float duration, float alpha, float alphaAmount, int amount, int maxSpeed, Color color)
        {
            var rnd = GameDevice.Instance().GetRandom();


            for (int i = 0; i < amount; i++)
            {
                int number = rnd.Next(50);

                if (number <= 25)
                {
                    name = "circle1";

                    float angle = 180;
                    float scale = rnd.Next(1, 4);
                    float speed = rnd.Next(10, maxSpeed);
                    Vector2 position = new Vector2(rnd.Next(1920), rnd.Next(1080));

                    //新しいパーティクルを作る
                    p = new Particle(name, position, speed, angle, scale, shrinkRate, duration, alpha, alphaAmount, color);

                    particles.Add(p);
                }

                else if (number >= 26)
                {
                    name = "circle2";

                    float angle = 180;
                    float scale = rnd.Next(1, 4);
                    float speed = rnd.Next(10, maxSpeed);
                    Vector2 position = new Vector2(rnd.Next(1920), rnd.Next(1080));

                    //新しいパーティクルを作る
                    p = new Particle(name, position, speed, angle, scale, shrinkRate, duration, alpha, alphaAmount, color);

                    particles.Add(p);
                }


            }
        }
    }
}
