using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GSeoFinalProject
{
    public class ActionScene : GameScene
    {
        Score score;
        public ActionScene(Game1 game) : base(game)
        {
            score = new Score(game);
        }

        public override void Initialize() {
            // create and add any components that belong to this scene
            this.SceneComponents.Add(new Background(game));
            this.SceneComponents.Add(new Fighter(game, score));
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
                //clear enemy --for restart game
                if (game.GameRestart)
                {
                    EnemyControl.enemyList.Clear();
                    score.CurrentScore = 0;
                    game.GameRestart = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    game.HideAllScenes();
                    game.Services.GetService<StartScene>().Show();

                }else if (game.GameOver==true)
                {
                    game.HideAllScenes();
                    //store score 
                    game.Services.GetService<EndGameScene>().Show();

                    game.GameOver = false; 
                }
            }
            base.Update(gameTime);
        }
    }
}
