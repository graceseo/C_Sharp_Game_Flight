using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GSeoFinalProject
{
    class Enemy
    {
        Game1 game;

        private Rectangle rectangle;
        Vector2 enemyPosition;

        Texture2D enemyTexture; //current enemy's image
        Texture2D explodedEnemy;

        SoundEffect explosionFX;

        private bool isHit = false;
        private bool isVisual=true;

        int serialNumber; // this enemy's number which will be divided by 3 for it's own way
        int remainder;
        int timerSinceHit;
        int timeShotWait;

        List<EnemyShot> ShotList;

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
        public bool IsHit { get => isHit; set => isHit = value; }
        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }

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

            explosionFX = game.Content.Load<SoundEffect>("Sounds/enemyExplosion");

            rectangle = new Rectangle((int)startposition.X, (int)startposition.Y, enemyTexture.Width, enemyTexture.Height);
            remainder = serialNumber % 3; //find the remainder for ramdom
            ShotList = new List<EnemyShot>();
        }
        /// <summary>
        /// enemies move by 3 different way by using Modulus opereator
        /// </summary>
        public void Update()
        {
            if (!IsHit)
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
                rectangle.Y = (int)enemyPosition.Y;

                // if this enemy's location is outside the window, remainder should be changed to opposite way
                if (enemyPosition.X <= 0)
                {
                    remainder = 0;
                }
                if (enemyPosition.X > (Game1.WINDOW_WIDTH - enemyTexture.Width))
                {
                    remainder = 1;
                }

                //this If statement controls enemy's spwan
                timeShotWait++;
                if (timeShotWait > 60)
                {
                    ShotList.Add(new EnemyShot(game, new Vector2(enemyPosition.X + (enemyTexture.Width - 20) / 2, (enemyPosition.Y + enemyTexture.Height-50))));
                    timeShotWait = 0;
                }

                // if an enemy collide the fighter, the fighter's heart should reduce
                if (rectangle.Intersects(Fighter.rectangle))
                {
                    Fighter.isHit = true;
                }

                foreach (EnemyShot shot in ShotList)
                {
                    shot.Update();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsHit)
            {
                spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
                foreach (EnemyShot shot in ShotList)
                {
                    shot.Draw(game.spriteBatch);
                }
            }
            else
            {
                timerSinceHit++;
                if (timerSinceHit < 40)
                {
                    explosionFX.Play(0.005f,0,0);
                    spriteBatch.Draw(explodedEnemy, enemyPosition, Color.White);
                }
            }
        }
    }
}
