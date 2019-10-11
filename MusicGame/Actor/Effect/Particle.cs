﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MusicGame.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame.Actor.Effect
{
    class Particle
    {
        private string name;//名前
        private Vector2 position;//位置
        private Vector2 direction;//向き
        public bool isDeadFlag;//死亡フラグ
        private float scale;
        private float shrinkRate;//　収縮する速度
        private float speed;
        public float duration;//寿命
        private float durationMax;
        private Vector2 origin;
        private Color color;
        private float rotate;
        private float alpha;
        private float alphaAmount;
        private float durationTime;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">画像名</param>
        /// <param name="position">位置</param>
        /// <param name="patarn">移動パターン</param>
        /// <param name="time">表示時間</param>
        /// <param name="mediator">仲介者</param>
        public Particle(string name, Vector2 position, float speed, float angle, float scale, float shrinkRate, float duration, float alpha, float alphaAmount, Color color)
        {
            isDeadFlag = false;
            this.name = name;
            this.position = position;
            this.speed = speed;
            this.scale = scale;
            this.shrinkRate = shrinkRate;
            this.duration = duration;
            origin = new Vector2(25, 10);
            this.alphaAmount = alphaAmount;
            this.alpha = alpha;


            this.color = color;
            //角度をラジアンに変更
            angle = MathHelper.ToRadians(angle);

            //角度から向きを獲得
            Vector2 up = new Vector2(0, -1.0f);
            Matrix rot = Matrix.CreateRotationZ(angle);
            direction = Vector2.Transform(up, rot);

            durationTime = duration - 3;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(float delta)
        {
            position += direction * speed * delta;

            scale -= shrinkRate * delta;

            duration -= delta;
            if (name == "traiangle1" || name == "traiangle2" ||
                            name == "traiangle3" || name == "traiangle4" || name == "circle1" || name == "circle2" || name == "fade")
            {
                if (duration > durationTime)
                {
                    alpha += alphaAmount;
                }

                if (alpha >= 0.5f)
                {
                    alpha = 0.5f;
                }

                if (duration < 3)
                {
                    alpha -= alpha * delta;
                }
            }


            if (scale <= 0.0f || duration <= 0.0f)
            {
                isDeadFlag = true;//時間外で死亡
            }
        }

        public bool IsDead()
        {
            return isDeadFlag;
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position, null, color, 0, origin, scale, SpriteEffects.None, alpha);
        }
    }
}

