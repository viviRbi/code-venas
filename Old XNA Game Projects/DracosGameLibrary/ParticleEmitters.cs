using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public class ParticleEmitters
    {
        public int particlecount = 300;
        public Vector2 position = Vector2.Zero;
        public Texture2D sprite;
        public Particles[] particle;
        public int current = 0;
        public int end = 300;
        public bool started = false;

        public ParticleEmitters(Vector2 newPosition)
        {
            //Random r = new Random();  
            particle = new Particles[particlecount];

            for (int i = 0; i < particlecount; i++)
            {
                particle[i] = new Particles();
                particle[i].velocity = new Vector2(10f, 10f);
                //new Vector2(0 + (float)r.Next(-100, 100) / 100f, -3 + (float)r.Next(-100, 100) / 100f);  
                //  
            }
            position = newPosition;
        }

        public void Init()
        {
            Random r = new Random();  
            particle = new Particles[particlecount];

            for (int i = 0; i < particlecount; i++)
            {
                particle[i] = new Particles();
                particle[i].velocity = new Vector2(15f, 15f);
                //particle[i].velocity = new Vector2(0 + (float)r.Next(-100, 100) / 100f, -3 + (float)r.Next(-100, 100) / 100f);
                //new Vector2(0 + (float)r.Next(-100, 100) / 100f, -3 + (float)r.Next(-100, 100) / 100f);  
                //  
            }
        }  

        public void Update(GameTime gameTime)
        {
            if (started)
            {
                for (int i = 0; i < 100; i++)
                {
                    current++;

                    if (current < particlecount)
                    {
                        // draw another particle starting at position  
                        particle[current].alive = true;
                        particle[current].position = new Vector2(100+(float)i,100+(float)i);
                    }
                }

                for (int i = 0; i < particlecount; i++)
                {
                    //update all active particles  
                    if (particle[i].alive)
                    {
                        particle[i].lifeTime++;

                        if (particle[i].lifeTime > end)
                        {
                            particle[i].alive = false;
                        }
                        else
                        {
                            //particle[i].velocity.Y += 9.8f / 50f;  
                            //particle[i].position = particle[i].position + particle[i].velocity;  
                            particle[i].position = particle[i].position + particle[i].velocity;

                        }
                    }
                }
            }
            else
            {
                current = 0;
                Init();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < particlecount; i++)
            {
                if (particle[i].alive)
                {
                    Color c = Color.White;
                    //c.A = (byte)((1 - (particle[i].lifeTime / (float)end)) * 255f);  
                    sb.Draw(sprite, particle[i].position, null, c, 0f, new Vector2(12, 12), .02f, SpriteEffects.None, 0);
                }
            }
        }
    }  
}
