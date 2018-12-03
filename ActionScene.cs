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

        public ActionScene(Game game) : base(game)
        {

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

            }
            base.Update(gameTime);
        }

    }
}
