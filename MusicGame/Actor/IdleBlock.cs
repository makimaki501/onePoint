using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using MusicGame.Device;
using MusicGame.Util;

namespace MusicGame.Actor
{
    class IdleBlock : GameObject
    {
        public IdleBlock(Vector2 position, GameDevice gameDevice)
            : base("Idle", position, 64, 64, gameDevice)
        {

        }
        public IdleBlock(IdleBlock other) : this(other.position, other.gameDevice)
        {

        }

        public override object Clone()
        {
            return new IdleBlock(this);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Hit(GameObject gameObject)
        {

        }
    }
}
