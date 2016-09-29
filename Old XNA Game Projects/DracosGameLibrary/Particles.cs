using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public class Particles
    {
        public bool alive = false;
        public Vector2 position = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        public int lifeTime = 0;
        public int rotation = 0;
        public int rotationspeed = 0;  
    }
}
