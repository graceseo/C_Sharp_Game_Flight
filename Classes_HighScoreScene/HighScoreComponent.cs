using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;

namespace GSeoFinalProject
{
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

        public override void Update(GameTime gameTime)
        {
            storedScore.Clear();
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
            base.Update(gameTime);
        }

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
