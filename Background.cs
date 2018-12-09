using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace GSeoFinalProject
{
    /// <summary>
    /// the background image is scrolling vertically.
    /// ActionScene, HighScoreScene, and EndGameScene include this class.
    /// </summary>
    public class Background : DrawableGameComponent
    {
        Game1 game;
  
        Texture2D spaceBackground;
        List<Rectangle> spaceRects = new List<Rectangle>();

        const int SPACE_SPEED = 1;
        public Background(Game1 game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            spaceBackground = game.Content.Load<Texture2D>("Images/background");

            int colCount = GraphicsDevice.Viewport.Height / spaceBackground.Height + 1;
            for (int i = 0; i < colCount; i++)
            {
                spaceRects.Add(new Rectangle(1,
                                            spaceBackground.Height * i,
                                            spaceBackground.Width,
                                            spaceBackground.Height));
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateRectPositionInList(spaceRects);
            UpdatePositions(spaceRects, SPACE_SPEED);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            foreach (Rectangle rect in spaceRects)
            {
                game.spriteBatch.Draw(spaceBackground, rect, Color.White);

            }
            game.spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        /// It moves all rectangle's position down.
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="speed"></param>
        private void UpdatePositions(List<Rectangle> rectList, int speed)
        {
            for (int i = 0; i < rectList.Count; i++)
            {
                Rectangle rect = rectList[i];
                rect.Y -= speed;
                rectList[i] = rect;
            }
        }

        /// <summary>
        /// Every game time, this method checks and adds a background image's rectagle
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="offset"></param>
        private void UpdateRectPositionInList(List<Rectangle> rectList, int offset = 0)
        {
            Rectangle firstRect = rectList[0];
            if (firstRect.Y < -firstRect.Height)
            {
                rectList.RemoveAt(0);
                Rectangle last = rectList[rectList.Count - 1];
                firstRect.Y = last.Y + last.Height + offset;
                rectList.Add(firstRect);
            }
        }
    }
}
