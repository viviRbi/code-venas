using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using DracosGameLibrary;
    using Microsoft.Xna.Framework.Content;


namespace GD
{
    
class MiniBoss
{
            ContentManager content;
            AnimationPlayer animationPlayer;
            public List<Projectile> miniBossShotList;
            public List<Texture2D> miniBossList;
            public List<Texture2D> miniBossListAnimate;
            public Animation minibossAnimation;
            public Texture2D shotSpriteAnimate;
            public Texture2D sprite;
            public Texture2D shotSprite;
            public Vector2 position;
            public float rotation;
            public Vector2 center;
            public Vector2 velocity;
            public bool alive;
            public int maxEnergyShots;
            public int life;
            public int shield;
            public int score;
            public int shotDelay;
            public int startShotDelay;
            public int damage;
            public int armor;
            public int startArmor;
            public int miniBossNumber=11;
            private int stage = 0;
            private int startLife;
            private int startShield;
            Random random = new Random();

            public MiniBoss(ContentManager content, Texture2D loadedTexture, int newLife, int newShield, int newScore, int newMaxShots, int newShotDelay, int newDamage)
            {
                rotation = 0.0f;
                position = Vector2.Zero;
                sprite = loadedTexture;
                center = new Vector2(sprite.Width / 2, sprite.Height / 2);
                velocity = Vector2.Zero;
                alive = false;
                life = newLife;
                shield = newShield;
                score = newScore;
                maxEnergyShots = newMaxShots;
                startShotDelay = newShotDelay;
                miniBossShotList = new List<Projectile>();
                this.content = content;
                damage = newDamage;
                LoadContent();
            }

            public MiniBoss(ContentManager content, Texture2D loadedTexture, int newLife, int newShield, int newScore, int newMaxShots, int newShotDelay, int newDamage, int newArmor)
            {
                this.content = content;
                miniBossList = new List<Texture2D>();
                miniBossListAnimate = new List<Texture2D>();
                rotation = 0.0f;
                position = Vector2.Zero;
                sprite = loadedTexture;
                center = new Vector2(sprite.Width / 2, sprite.Height / 2);
                velocity = Vector2.Zero;
                alive = false;
                life = newLife;
                shield = newShield;
                score = newScore;
                maxEnergyShots = newMaxShots;
                startShotDelay = newShotDelay;
                miniBossShotList = new List<Projectile>();
                damage = newDamage;
                armor = newArmor;
                startArmor = armor;
                LoadContent();
            }

            public MiniBoss(ContentManager content,Player player,int stage,Boss boss)
            {
                this.content = content;
                this.stage = stage;
                miniBossList = new List<Texture2D>();
                LoadMiniBosses();
                InitStats(player,boss);
                rotation = 0.0f;
                position = Vector2.Zero;
                int miniBossType = random.Next(0, miniBossNumber);
                sprite = miniBossList[miniBossType];
                center = new Vector2(sprite.Width / 2, sprite.Height / 2);
                velocity = Vector2.Zero;
                alive = false;
                miniBossShotList = new List<Projectile>();
                damage = 2;
                startArmor = armor;
                startLife = life;
                startShield = shield;
                LoadContent();
                Load(miniBossList[miniBossType], 128, 0.2f);
            }

            public void LoadContent()
            {
                shotSprite = content.Load<Texture2D>("Sprites/Projectile/miniBoss/shot1");
                shotSpriteAnimate = content.Load<Texture2D>("Sprites/Projectile/miniBoss/shot1N");
            }

            public void Load(Texture2D newTexture, int newFrameWidth, float newFrameTime)
            {
                minibossAnimation = new Animation(newTexture, newFrameWidth, newFrameTime, true);
            }

            public void LoadMiniBosses()
            {
                String location;
                Texture2D texture;
                for (int i = 1; i <= miniBossNumber; i++)
                {
                    location = "Sprites/MiniBoss/miniBoss" + i + "N";
                    texture = content.Load<Texture2D>(location);
                    miniBossList.Add(texture);
                }
            }

            public void InitStats(Player player,Boss boss)
            {
                maxEnergyShots = 5 + (player.plasmaShotDmg / 6);
                startShotDelay = 150 - (player.secondaryShotDmg / 6);
                if (startShotDelay <= 0)
                    startShotDelay = 2;

                armor = 1 + (player.plasmaShotDmg + player.secondaryShotDmg) + (stage * 3);
                score = (500 * stage) - player.ultimateWeaponDmg;
                life = boss.life / 6;
                shield = life + maxEnergyShots;
            }


            public void Update()
            {
                if (alive)
                {
                    animationPlayer.PlayAnimation(minibossAnimation);
                }
                System.Diagnostics.Debug.Print("MiniBoss armor:" + startArmor+":life:"+startLife+":shield:"+startShield);

            }

            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                SpriteEffects flip = SpriteEffects.None;
                animationPlayer.Draw(gameTime, spriteBatch, position, flip);
                foreach (Projectile p in miniBossShotList)
                    p.Draw(gameTime, spriteBatch);
            }

            public virtual Rectangle MiniBossRect()
            {
                return new Rectangle(
                (int)position.X,
                (int)position.Y/3,
                sprite.Width,
                sprite.Height);
            }

            public virtual Rectangle MiniBossRectL()
            {
                return new Rectangle(
                (int)position.X,
                (int)position.Y*2,
                sprite.Width,
                sprite.Height);
            }

            public void MiniBossShoot()
            {
                if (alive)
                {
                    if (shotDelay >= 0)
                        shotDelay--;
                    int fire = random.Next(10, 10);

                    if (fire == 10 && shotDelay <= 0)
                    {
                        Projectile newShot = new Projectile(shotSprite);
                        newShot.Load(shotSpriteAnimate, 32, 0.1f);
                        newShot.position = position - newShot.center + center+ new Vector2(-50,-100);
                        newShot.velocity.Y = 3.5f;
                        newShot.velocity.X = (float)random.Next(-8, 8);
                        newShot.alive = true;

                        if (miniBossShotList.Count < maxEnergyShots)
                            miniBossShotList.Add(newShot);
                        newShot.Update();
                    }

                    if (shotDelay == 0)
                        shotDelay = startShotDelay;
                }
            }

            public void MiniBossDualShoot()
            {
                if (alive)
                {
                    if (shotDelay >= 0)
                        shotDelay--;
                    int fire = random.Next(10, 10);

                    if (fire == 10 && shotDelay <= 0)
                    {
                        Projectile newShot = new Projectile(shotSprite);
                        Projectile newShot2 = new Projectile(shotSprite);
                        newShot.Load(shotSpriteAnimate, 32, 0.2f);
                        newShot2.Load(shotSpriteAnimate, 32, 0.2f);
                        
                        newShot.position = position - center + newShot.center;
                        newShot2.position = position - center + newShot2.center + new Vector2(sprite.Width-newShot2.sprite.Width,0);
                        
                        newShot.velocity.Y = 4.5f;
                        newShot2.velocity.Y = 5.5f;
                        
                        newShot.velocity.X = (float)random.Next(-6, 6);
                        newShot2.velocity.X = (float)random.Next(-9, 9);
                        
                        newShot.alive = true;
                        newShot2.alive = true;

                        if (miniBossShotList.Count < maxEnergyShots)
                        {
                            miniBossShotList.Add(newShot);
                            miniBossShotList.Add(newShot2);
                        }
                        newShot.Update();
                        newShot2.Update();
                    }

                    if (shotDelay == 0)
                        shotDelay = startShotDelay;
                }
            }

            public void UpdateShot(Player playership)
            {
                
                    foreach (Projectile p in miniBossShotList)
                    {
                        if (playership.ultimateWeaponAlive)
                            p.alive = false;
                        else
                            p.position += p.velocity;

                        if (p.position.Y > 1000)
                            p.alive = false;
                    }

                    for (int i = 0; i < miniBossShotList.Count; i++)
                    {
                        if (!miniBossShotList[i].alive)
                        {
                            miniBossShotList.RemoveAt(i);
                            i--;
                        }
                    }
                
            }

            public void UpdateMiniBoss(GameTime gameTime, Rectangle Safe, Player player)
            {
                if (alive)
                {
                    if (life > 0)
                    {
                        position += velocity;

                        if (position.X < player.position.X)
                        {
                            velocity.X = 4.0f;
                        }
                        else if (position.X > player.position.X)
                        {
                            velocity.X = -4.0f;
                        }
                        if (position.X > player.position.X)
                            if(position.X - player.position.X <= 50)
                                velocity.X = 0.0f;
                        if (player.position.X > position.X)
                            if (player.position.X - position.X <= 50)
                                velocity.X = 0.0f;
                    }
                    System.Diagnostics.Debug.Print("MiniBossPOSX:" + (position.X) + ":playerPosX:" + (player.position.X) + ":velX:" + velocity.X);
                }

                else if (life > 0)
                {
                    alive = true;
                    position.X = (Safe.Width + sprite.Width) / 2;
                    position.Y = (Safe.Height + sprite.Height) / 5;
                    velocity.X = 2.0f;
                }

            }

    }
}
