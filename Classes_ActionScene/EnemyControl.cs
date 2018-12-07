using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSeoFinalProject
{
    /// <summary>
    /// This class makes, updates, and draws enemies and rocks
    /// A rock appear more slow than Enemy fighters
    /// </summary>
    class EnemyControl : DrawableGameComponent
    {
        Game1 game;
        
        //This List shoud be static becuase Shot class check it's isHit variable, and when an enemy got hit, that enemy will be removed.
        static internal List<Enemy> enemyList;
        public List<Rock> rockList;

        //All emeny has a serial number, so an enemy can move different way.
        public int enemySerialNo = 1;

        double enemySpwan;
        double rockSpwan;

        Random random;
        public EnemyControl(Game1 game) : base(game)
        {
            this.game = game;
            enemyList = new List<Enemy>();
            rockList = new List<Rock>();
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
                //enemySpwan variable controls how often an enemy occur
                enemySpwan += gameTime.ElapsedGameTime.TotalSeconds;
                //rockSpwan variable controls how often an enemy occur
                rockSpwan += gameTime.ElapsedGameTime.TotalSeconds;

                if (rockSpwan > 7)
                {
                    Rock rock = new Rock(game, new Vector2(random.Next(game.GraphicsDevice.Viewport.Width - 10), 30));
                    rockList.Add(rock);
                    rockSpwan = 0;
                }
                if (enemySpwan > 3)
                {
                    Enemy enemy = new Enemy(game, new Vector2(random.Next(game.GraphicsDevice.Viewport.Width - 5), 0), enemySerialNo);
                    enemyList.Add(enemy);
                    enemySerialNo += 1;
                    enemySpwan = 0;
                }

                foreach (Rock rock in rockList)
                {
                    rock.Update();
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
            foreach (Rock rock in rockList)
            {
                rock.Draw(game.spriteBatch);
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(game.spriteBatch);
            }
            game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
