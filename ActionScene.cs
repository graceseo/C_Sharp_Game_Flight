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
        //when the fighter is dead, the fighter class will change gameOver variable true.
        static public bool gameOver = false;
        public ActionScene(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
             // create and add any components that belong to this scene
            this.SceneComponents.Add(new Background(game));
            this.SceneComponents.Add(new Fighter(game));
            this.SceneComponents.Add(new EnemyControl(game));
            base.Initialize();
        }

        /// <summary>
        /// when the fighter has no heart, this scene shows the EndGameScene
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    game.HideAllScenes();
                    game.Services.GetService<StartScene>().Show();
                }else if (gameOver==true)
                {
                    game.HideAllScenes();
                    game.Services.GetService<EndGameScene>().Show();
                }
            }
            base.Update(gameTime);
        }
    }
}
