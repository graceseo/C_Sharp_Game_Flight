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

        Texture2D enemyTexture; //current enemy's image
        Texture2D explodedEnemy;

        bool isHit = false;
        bool isVisual=true;

        int serialNumber; // this enemy's number which will be divided by 3 for it's own way
        int remainder;

        Random random = new Random();

        // array of possible enemy names since enemies are made at random
        string[] enemyType =
        {
            "enemyBlue",
            "enemyWhite",
            "enemyYellow"
        };

        /// <summary>
        /// If an enemy is below the bottom of the window, it should be invisible
        /// </summary>
        public bool IsVisual { get => isVisual; set => isVisual = value; }

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

            explodedEnemy = game.Content.Load<Texture2D>("Images/smallExplosion");
            string textureName = enemyType[random.Next(enemyType.Length)];
            enemyTexture = game.Content.Load<Texture2D>("Images/"+textureName);

            rectangle = new Rectangle((int)startposition.X, (int)startposition.Y, enemyTexture.Width, enemyTexture.Height);
            remainder = serialNumber % 3; //find the remainder
        }
        /// <summary>
        /// enemies move by 3 different way by using Modulus opereator
        /// </summary>
        public void Update()
        {
            if (isHit == false)
            {
                switch (remainder)
                {
                    case 0:
                        enemyPosition.X += 1f;
                        break;
                    case 1:
                        enemyPosition.X -= 1f;
                        break;
                    default:
                        break;
                }
                enemyPosition.Y += 1f; //all enemy will get down
                rectangle.X = (int)enemyPosition.X;

                // if this enemy's location is outside the window, remainder should be changed to opposite way
                if (enemyPosition.X <= 0)
                {
                    remainder = 0;
                }
                if (enemyPosition.X > (Game1.WINDOW_WIDTH - enemyTexture.Width))
                {
                    remainder = 1;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isHit == false)
            {
                spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
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
