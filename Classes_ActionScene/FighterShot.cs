using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GSeoFinalProject
{
    class FighterShot
    {
        Game1 game;
        Score score;
        Rectangle rectangle;

        Texture2D shotTexture;

        public FighterShot(Game1 game, Score score, Vector2 startLocation)
        {
            this.game = game;
            this.score = score;
            shotTexture = game.Content.Load<Texture2D>("Images/fighterShot");
            rectangle = new Rectangle((int)startLocation.X, (int)startLocation.Y, shotTexture.Width, shotTexture.Height);
        }

        /// <summary>
        ///A shot's Y moves down
        ///if the fighter's shot hit en enemy which is not hit, the fighter get score
        /// </summary>
        public void Update()
        {
            rectangle.Y -= 10;

            for (int i=0; i<EnemyControl.enemyList.Count; i++)
            {
                if (rectangle.Intersects(EnemyControl.enemyList[i].Rectangle) && EnemyControl.enemyList[i].IsHit==false)
                {
                    EnemyControl.enemyList[i].IsHit = true;
                    score.CurrentScore += 100; //score 100 is fixed
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
