using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class Fighter : DrawableGameComponent
    {
        Game1 game;

        Texture2D fighterIdle;
        Texture2D fighterLeft;
        Texture2D fighterRight;

        Texture2D fighterCurrent;

        Vector2 fighterPosition;
        const int SPEED = 5;
        List<Shot> fighterShotList;
        bool shotEnable = true;

        public Fighter(Game1 game) : base(game)
        {
            this.game = game;
            fighterShotList = new List<Shot>();
        }
        protected override void LoadContent()
        {
            fighterIdle = game.Content.Load<Texture2D>("Images/fighter");
            fighterLeft = game.Content.Load<Texture2D>("Images/fighterLeft");
            fighterRight = game.Content.Load<Texture2D>("Images/fighterRight");

            fighterPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - fighterIdle.Width / 2,
                                        GraphicsDevice.Viewport.Height - fighterIdle.Height);
            fighterCurrent = fighterIdle;
            base.LoadContent();
        }

        /// <summary>
        /// This Update method includes Fighter and Shot update.
        /// When a fighter moves, it shouldn't move into outside this window, 
        /// so every direction keyboards' action calculate this fighter's position and the window size
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && fighterPosition.X>0)
            {
                fighterCurrent = fighterLeft;
                fighterPosition.X -= SPEED;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && fighterPosition.X < (Game1.WINDOW_WIDTH- fighterIdle.Width))
            {
                fighterCurrent = fighterRight;
                fighterPosition.X += SPEED;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                fighterCurrent = fighterIdle;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                fighterCurrent = fighterIdle;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && fighterPosition.Y>0)
            {
                fighterCurrent = fighterIdle;
                fighterPosition.Y -= SPEED;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && fighterPosition.Y < (Game1.WINDOW_HEIGHT - fighterIdle.Height))
            {
                fighterCurrent = fighterIdle;
                fighterPosition.Y += SPEED;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && shotEnable)
            {
                fighterShotList.Add(new Shot(game, new Vector2(fighterPosition.X + (fighterIdle.Width-20) / 2, fighterPosition.Y)));
                shotEnable = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                shotEnable = true;
            }

            foreach (Shot shot in fighterShotList)
            {
                shot.Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(fighterCurrent, fighterPosition, Color.White);
            foreach (Shot shot in fighterShotList)
            {
                shot.Draw(game.spriteBatch);
            }
            game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
