using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSeoFinalProject
{
    /// <summary>
    /// This class make, update, and draw enemies.
    /// </summary>
    class EnemyControl : DrawableGameComponent
    {
        Game1 game;
        
        //This List shoud be static becuase Shot class check it's isHit variable
        static internal List<Enemy> enemyList;

        //All emeny has a serial number, so an enemy can move different way.
        public int enemySerialNo = 1;

        double spwan;

        Random random;
        public EnemyControl(Game1 game) : base(game)
        {
            this.game = game;
            enemyList = new List<Enemy>();
            random = new Random();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                spwan += gameTime.ElapsedGameTime.TotalSeconds;
                //this if statement control how often an enemy occur
                if (spwan >3)
                {
                    enemyList.Add(new Enemy(game, new Vector2(random.Next(game.GraphicsDevice.Viewport.Width - 5), 0), enemySerialNo));
                    enemySerialNo += 1;
                    spwan = 0;
                }
                foreach (Enemy enemy in enemyList)
                {
                    enemy.Update();
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(game.spriteBatch);
            }
            game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
