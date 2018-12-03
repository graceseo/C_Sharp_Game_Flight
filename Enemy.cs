using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GSeoFinalProject
{
    class Enemy
    {
        Game1 game;

        Rectangle rectangle;
        Vector2 enemyPosition;

        Texture2D enemyFighter;
        Texture2D explodedEnemy;

        bool hit = false;
        bool isVisual = true;

        int serialNumber;
        int remainder;

        //int randomX; //if this enemy's position is outsite of the window, this variable could be applied enemy's position
        //int randomY;

        Random random = new Random();

        /// <summary>
        /// the enemy constructor must get this enemy's serial number.
        /// each enemy has 3 different way to appear by dividing a serial number.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="startposition"></param>
        /// <param name="serialNo"></param>
        public Enemy(Game1 game, Vector2 startposition, int serialNo)
        {
            this.game = game;
            enemyPosition = startposition;
            serialNumber = serialNo;
            enemyFighter = game.Content.Load<Texture2D>("Images/solorEnemySmall");
            explodedEnemy = game.Content.Load<Texture2D>("Images/smallExplosion");
            rectangle = new Rectangle((int)startposition.X, (int)startposition.Y, enemyFighter.Width, enemyFighter.Height);
            //randomX = random.Next(-2, 3);
            //randomY = random.Next(-2, -1);
            remainder = serialNumber % 3; //find the remainder
        }

        /// <summary>
        /// If this emeny doesn't get hit, it moves by 3 different way by using Modulus opereator
        /// </summary>
        public void Update()
        {
            if (hit == false)
            {
                switch (remainder)
                {
                    case 0:
                        enemyPosition.X += 0.2f;
                        break;
                    case 1:
                        enemyPosition.X -= 0.2f;
                        break;
                    default:
                        break;
                }
                enemyPosition.Y += 0.2f; //all enemy will get down
                
                rectangle.X = (int)enemyPosition.X;

                if (enemyPosition.Y<= 0)
                {
                    isVisual = false;
                }

                // if this enemy's location is outside the window, remainder should be changed to opposite way
                if (enemyPosition.X<=0)
                {
                    remainder = 0;
                }
                if (enemyPosition.X > Game1.WINDOW_WIDTH)
                {
                    remainder = 1;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (hit == false)
            {
                //if (enemyPosition.X < game.GraphicsDevice.Viewport.Width)
                //{
                    spriteBatch.Draw(enemyFighter, enemyPosition, Color.White);
                //}
            }
            else
            {
                //timerSinceHit++;
                //if (timerSinceHit < 60)
                //{
                //    spriteBatch.Draw(explodedMeteor, location, Color.White);
                //}
            }
        }
    }
}
