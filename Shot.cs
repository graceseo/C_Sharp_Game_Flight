using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class Shot
    {
        Game1 game;
        Rectangle rectangle;

        Texture2D shotTexture;
        
        public Shot(Game1 game, Vector2 startLocation)
        {
            this.game = game;
            shotTexture = game.Content.Load<Texture2D>("Images/fighterShot");
            rectangle = new Rectangle((int)startLocation.X, (int)startLocation.Y, shotTexture.Width, shotTexture.Height);
        }

        public void Update()
        {
            rectangle.Y -= 10;

            //loop the static enemyList of EnemyControl Class
            foreach (Enemy enemy in EnemyControl.enemyList)
            {
                if (rectangle.Intersects(enemy.Rectangle))
                {
                    enemy.IsHit=true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (rectangle.Y > shotTexture.Height * -1)
            {
                spriteBatch.Draw(shotTexture, rectangle, Color.White);

            }
        }

    }
}
