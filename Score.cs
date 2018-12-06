using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    /// <summary>
    /// This class store high score, and it shows a current score
    /// </summary>
    class Score
    {

        const int SCORE_WEIGHT = 100;
        static internal int currentScore = 0;

        List<int> scoreList = new List<int>();

        /// <summary>
        /// This is for the const variable by read only
        /// </summary>
        public static int scoreWeight => SCORE_WEIGHT;
    }
}
