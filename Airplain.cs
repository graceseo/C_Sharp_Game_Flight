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
    class Airplain : DrawableGameComponent
    {
        Game1 game;

        Texture2D fighterIdle;
        Texture2D fighterLeft;
        Texture2D fighterRight;

        Texture2D fighterCurrent;

        Vector2 fighterPosition;
        const int SPEED = 5;

        public Airplain(Game1 game) : base(game)
        {
            this.game = game;
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
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                fighterCurrent = fighterLeft;
                fighterPosition.X -= SPEED;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
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
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                fighterCurrent = fighterIdle;
                fighterPosition.Y -= SPEED;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                fighterCurrent = fighterIdle;
                fighterPosition.Y += SPEED;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(fighterCurrent, fighterPosition, Color.White);
            game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
