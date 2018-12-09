using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Collections.Generic;

namespace GSeoFinalProject
{
    /// <summary>
    /// It loads a high score file to show scores
    /// </summary>
    class HighScoreTextComponent : DrawableGameComponent
    {
        Game1 game;

        SpriteFont notificationFont;

        List<String> storedScore;

        Texture2D highScore;

        Vector2 position;
        Vector2 positionWord;
        public HighScoreTextComponent(Game game) : base(game)
        {
            this.game = game as Game1;
            storedScore = new List<string>();
        }


        public override void Initialize()
        {
            positionWord = new Vector2((GraphicsDevice.Viewport.Width - 200) / 2,
                          (GraphicsDevice.Viewport.Height) / 2);
            position = new Vector2(200, 200);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            notificationFont = game.Content.Load<SpriteFont>("Fonts/highScore");
            highScore = game.Content.Load<Texture2D>("Images/highScoreLogo");
            base.LoadContent();
        }

        /// <summary>
        /// to find a file for high scores and add scores into a LIST variable if a file exsits.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            storedScore.Clear();
            try
            {
                if (File.Exists(game.filename))
                {
                    //Add stored scores to List
                    game.scoreReader = new StreamReader(game.filename);
                    while (!game.scoreReader.EndOfStream)
                    {
                        storedScore.Add(game.scoreReader.ReadLine());
                    }
                    game.scoreReader.Close();
                }
            }
            catch (Exception ex)
            {
                //if there is any error, this component will be closed and go start page.
                game.HideAllScenes();
                game.Services.GetService<StartScene>().Show();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// to show scores from a LIST variable.  
        /// </summary>
        /// <param name="gameTime"></param>

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = game.Services.GetService<SpriteBatch>();
            Vector2 tempPos = positionWord;
            spriteBatch.Begin();

            spriteBatch.Draw(highScore, position, Color.White);

            foreach (string scoreWord in storedScore)
            {
                spriteBatch.DrawString(notificationFont, scoreWord, tempPos, Color.White);
                tempPos.Y += notificationFont.LineSpacing;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
