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

                sortedScore.Sort();

                //check Stored Scores are 5, and the lowest score is less than a current socre
                if (sortedScore.Count>=maxNumberScores && sortedScore[0]<currentScore)
                {
                    sortedScore.RemoveAt(0);
                    sortedScore.Add(currentScore);

                }else if (sortedScore.Count<maxNumberScores)
                {
                    sortedScore.Add(currentScore);
                }
            }
        }

        /// <summary>
        /// this method is called to wirte a score in a file.
        /// </summary>
        public void OpenFile()
        {
            bool isNewFile = false;
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
            game.scoreWriter.Close();
        }

        /// <summary>
        ///to write score in a file.
        ///if this is new file, this method will just save a current score
        /// </summary>
        public void WriteScore(bool isNewFile)
        {
            if (isNewFile == true)
            {
                game.scoreWriter.WriteLine(currentScore.ToString());
            }
            else
            {
                foreach (int scores in sortedScore)
                {
                    game.scoreWriter.WriteLine(scores.ToString());
                }
            }
        }

        //// Open the file to read from.
        //using (StreamReader sr = File.OpenText(game.filename))
        //{
        //    string s = "";
        //    while ((s = sr.ReadLine()) != null)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}

    }
}
