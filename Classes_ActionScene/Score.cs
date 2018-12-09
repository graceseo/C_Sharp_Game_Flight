using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GSeoFinalProject
{
    /// <summary>
    /// This class store high score into a file, and it shows a current score
    /// </summary>
    class Score
    {
        Game1 game;
        private int currentScore = 0;
        private int maxNumberScores = 5;

        List<String> storedScore;
        List<int> sortedScore;

        SpriteFont scoreWords;
        Vector2 scorePosition;

        public int CurrentScore { get => currentScore; set => currentScore = value; }

        public Score(Game1 game)
        {
            this.game = game;

            scorePosition = new Vector2((game.GraphicsDevice.Viewport.Width - 200), 0);

            scoreWords = game.Content.Load<SpriteFont>("Fonts/regularFont");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(scoreWords, currentScore.ToString(), scorePosition, Color.White);
        }

        /// <summary>
        /// When the fighter is died, this method will save a score in a file if a current score is more high than other scores
        /// </summary>
        public void SaveScore()
        {
            storedScore = new List<string>();
            sortedScore = new List<int>();

            CompareScore();
            OpenFile();

        }
        /// <summary>
        /// to compare current socre with othe scores in a file if a file exists.
        /// if the lowest score in the file is more less than a current score, it's going to be removed from the List.
        /// </summary>
        public void CompareScore()
        {
            try
            {
                //if a file doesn't exist or sotred socred are less than 5, comparing doesn't need
                if (File.Exists(game.filename))
                {
                    //Add stored scores to List
                    game.scoreReader = new StreamReader(game.filename);
                    while (!game.scoreReader.EndOfStream)
                    {
                        storedScore.Add(game.scoreReader.ReadLine());
                    }
                    game.scoreReader.Close();

                    //Convert scores in String to  Int
                    sortedScore = storedScore.ConvertAll(int.Parse);

                    sortedScore.Add(currentScore);
                    sortedScore.Sort();

                    sortedScore.Reverse();
                }
            }
            catch (Exception ex)
            {
                //if there is any error, this component will be closed and go start page.
                game.HideAllScenes();
                game.Services.GetService<StartScene>().Show();
            }
        }

        /// <summary>
        /// this method is called to wirte a score in a file.
        /// </summary>
        public void OpenFile()
        {
            bool isNewFile = false;

            try
            {
                if (!File.Exists(game.filename))
                {
                    isNewFile = true;
                    // Create a file to write to
                    using (game.scoreWriter = File.CreateText(game.filename))
                    {
                        WriteScore(isNewFile);
                    }
                }
                else
                {
                    isNewFile = false;
                    // if a file exists just write
                    game.scoreWriter = new StreamWriter(game.filename);
                    WriteScore(isNewFile);
                }
            }catch(Exception ex)
            {
                //if there is any error, this component will be closed and go start page.
                game.HideAllScenes();
                game.Services.GetService<StartScene>().Show();
            }
            game.scoreWriter.Close();
        }

        /// <summary>
        ///to write score in a file.
        ///if this is new file, this method will just save a current score
        /// </summary>
        public void WriteScore(bool isNewFile)
        {
            try
            {
                if (isNewFile == true)
                {
                    game.scoreWriter.WriteLine(currentScore.ToString());
                }
                else
                {
                    for (int i = 0; i < maxNumberScores && i <= storedScore.Count; i++)
                    {
                        game.scoreWriter.WriteLine(sortedScore[i].ToString());
                    }

                }
            }catch(Exception ex)
            {
                //if there is any error, this component will be closed and go start page.
                game.HideAllScenes();
                game.Services.GetService<StartScene>().Show();
            }
        }
    }
}
