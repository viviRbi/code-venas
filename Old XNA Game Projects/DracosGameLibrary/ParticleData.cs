using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public class ParticleDataSystem
    {
        struct ParticleData
        {
            public float BirthTime;
            public float MaxAge;
            public Vector2 OrginalPosition;
            public Vector2 Accelaration;
            public Vector2 Direction;
            public Vector2 Position;
            public float Scaling;
            public Color ModColor;
        }

        List<ParticleData> particleList;
        List<ParticleData> bossHitList;
        List<ParticleData> bossShieldHitList;
        List<ParticleData> boomList;
        private Random randomizer = new Random();

        public ParticleDataSystem()
        {
            particleList = new List<ParticleData>();
            boomList = new List<ParticleData>();
            bossHitList = new List<ParticleData>();
            bossShieldHitList = new List<ParticleData>();
        }

        public void AddBoom(Vector2 explosionPos, int numberOfParticles, float size, float maxAge, GameTime gameTime)
        {
            for (int i = 0; i < numberOfParticles; i++)
                AddParticle(boomList, explosionPos, size, maxAge, gameTime);
        }

        public void AddExplosion(Vector2 explosionPos, int numberOfParticles, float size, float maxAge, GameTime gameTime)
        {
            for (int i = 0; i < numberOfParticles; i++)
                AddParticle(particleList, explosionPos, size, maxAge, gameTime);
        }

        public void AddBossHit(Vector2 explosionPos, int numberOfParticles, float size, float maxAge, GameTime gameTime)
        {
            for (int i = 0; i < numberOfParticles; i++)
                AddParticle(bossHitList, explosionPos, size, maxAge, gameTime);
        }

        public void AddBossShieldHit(Vector2 explosionPos, int numberOfParticles, float size, float maxAge, GameTime gameTime)
        {
            for (int i = 0; i < numberOfParticles; i++)
                AddParticle(bossShieldHitList, explosionPos, size, maxAge, gameTime);
        }

        private void AddParticle(List<ParticleData> particleList,Vector2 explosionPos, float explosionSize, float maxAge, GameTime gameTime)
        {
            ParticleData particle = new ParticleData();

            particle.OrginalPosition = explosionPos;
            particle.Position = particle.OrginalPosition;

            particle.BirthTime = (float)gameTime.TotalGameTime.TotalMilliseconds;
            particle.MaxAge = maxAge;
            particle.Scaling = 0.65f;
            particle.ModColor = Color.White;

            float particleDistance = (float)randomizer.NextDouble() * explosionSize;
            Vector2 displacement = new Vector2(particleDistance, 0);
            float angle = MathHelper.ToRadians(randomizer.Next(360));
            displacement = Vector2.Transform(displacement, Matrix.CreateRotationZ(angle));


            particle.Direction = displacement * 5.0f;
            particle.Accelaration = -particle.Direction;

            particleList.Add(particle);
        }

        

       

        public void Update(GameTime gameTime)
        {
            if (particleList.Count > 0)
                UpdateParticles(particleList,gameTime);
            if (boomList.Count > 0)
                UpdateParticles(boomList,gameTime);
            if (bossHitList.Count > 0)
                UpdateParticles(bossHitList, gameTime);
            if (bossShieldHitList.Count > 0)
                UpdateParticles(bossShieldHitList, gameTime);
        }

        private void UpdateParticles(List<ParticleData> particleList, GameTime gameTime)
        {
            float now = (float)gameTime.TotalGameTime.TotalMilliseconds;
            for (int i = particleList.Count - 1; i >= 0; i--)
            {
                ParticleData particle = particleList[i];
                float timeAlive = now - particle.BirthTime;

                if (timeAlive > particle.MaxAge)
                {
                    particleList.RemoveAt(i);
                }
                else
                {
                    float relAge = timeAlive / particle.MaxAge;
                    particle.Position = 0.5f * particle.Accelaration * relAge * relAge + particle.Direction * relAge + particle.OrginalPosition;

                    float invAge = 1.0f - relAge;
                    particle.ModColor = new Color(new Vector4(invAge, invAge, invAge, invAge));

                    Vector2 positionFromCenter = particle.Position - particle.OrginalPosition;
                    float distance = positionFromCenter.Length();
                    particle.Scaling = (50.0f + distance) / 200.0f;

                    particleList[i] = particle;
                }
            }
        }

        public void DrawExplosion(Texture2D newTexture,SpriteBatch spriteBatch)
        {
            for (int i = 0; i < particleList.Count; i++)
            {
                ParticleData particle = particleList[i];
                spriteBatch.Draw(newTexture, particle.Position, null, particle.ModColor, i, new Vector2(256, 256), particle.Scaling, SpriteEffects.None, 1);
            }
        }

        public void DrawBossHit(Texture2D newTexture, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bossHitList.Count; i++)
            {
                ParticleData particle = bossHitList[i];
                spriteBatch.Draw(newTexture, particle.Position, null, particle.ModColor, i, new Vector2(256, 256), particle.Scaling, SpriteEffects.None, 1);
            }
        }

        public void DrawBossShieldHit(Texture2D newTexture, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bossShieldHitList.Count; i++)
            {
                ParticleData particle = bossShieldHitList[i];
                spriteBatch.Draw(newTexture, particle.Position, null, particle.ModColor, i, new Vector2(256, 256), particle.Scaling, SpriteEffects.None, 1);
            }
        }

        public void DrawParticles(Texture2D newTexture,SpriteBatch spriteBatch)
        {
            for (int i = 0; i < particleList.Count; i++)
            {
                ParticleData particle = particleList[i];
                spriteBatch.Draw(newTexture, particle.Position, null, particle.ModColor, i, new Vector2(256, 256), particle.Scaling, SpriteEffects.None, 1);
            }
        }

        public void DrawBoom(Texture2D newTexture,SpriteBatch spriteBatch)
        {
            for (int i = 0; i < boomList.Count; i++)
            {
                ParticleData boom = boomList[i];
                spriteBatch.Draw(newTexture, boom.Position, null, boom.ModColor, i, new Vector2(256, 256), boom.Scaling, SpriteEffects.None, 1);
            }
        }

    }

     

}
