using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class GroupEnemy: Enemy
    {
        Game1 game;
        internal Rectangle rectangle;
        Vector2 position;
        Texture2D groupEnemey;
        Texture2D explodedEnemy;
        bool isHit = false;
        //bool explosionPlayed = false;
        int timerSinceHit;

        public GroupEnemy(Game1 game): base(game)
        {
            //this.game = game;
            //location = startLocation;
            //meteor = game.Content.Load<Texture2D>("meteorSmall");
            //explodedMeteor = game.Content.Load<Texture2D>("laserRedShot");
            //explosionFX = game.Content.Load<SoundEffect>("Explosion_03");
            //rectangle = new Rectangle((int)startLocation.X, (int)startLocation.Y, meteor.Width, meteor.Height);

            // rectangle = new Rectangle((int)startLocation.X, (int)startLocation.Y, meteor.Width, meteor.Height);
        }
        protected override void LoadContent()
        {
            groupEnemey = game.Content.Load<Texture2D>("emenyWhite");
            explodedEnemy = game.Content.Load<Texture2D>("smallExplosion");

            base.LoadContent();
        }
        public void Update()
        {
            if (isHit == false)
            {
                position.Y -= 0.2f;
                rectangle.Y = (int)position.Y;
            }
            else
            {
                //if (explosionPlayed == false)
               // {
               //     explosionPlayed = true;
               // }

            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (isHit == false)
            {
                if (position.X < game.GraphicsDevice.Viewport.Width)
                {
                    //spriteBatch.Draw(meteor, position, Color.White);
                }
            }
            else
            {
                timerSinceHit++;
                if (timerSinceHit < 60)
                {
                   // spriteBatch.Draw(explodedMeteor, position, Color.White);
                }
            }




        }
    }
}
