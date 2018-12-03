using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    public class ActionScene : GameScene
    {
        //enemies must be at least 5
        public const int MIN_ENEMY_COUNT = 5;
        public const int MAX_ENEMY_COUNT = 20;

        //All emeny has their own serial number, so an enemy can move different way.
        public int enemySerialNo = 1;

        internal List<Enemy> enemyList;
        double spwan;

        Random random ;

        public ActionScene(Game game) : base(game)
        {
            enemyList = new List<Enemy>();
            random = new Random();
        }

        public override void Initialize()
        {
            // create and add any components that belong to this scene
            this.SceneComponents.Add(new Background(game));
            this.SceneComponents.Add(new Fighter(game));
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    game.HideAllScenes();
                    game.Services.GetService<StartScene>().Show();
                }
                spwan += gameTime.ElapsedGameTime.TotalSeconds;
                if (spwan > 3)
                {
                    enemyList.Add(new Enemy(game, new Vector2(random.Next(game.GraphicsDevice.Viewport.Width), 0), enemySerialNo));
                    spwan = 0;
                }

                foreach (Enemy enemy in enemyList)
                {
                    enemy.Update();
                }
            }
            base.Update(gameTime);
        }

    }
}
