using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DracosGameLibrary
{
    [Serializable]
    public struct HighScoreData
    {
        public string[] PlayerName;
        public int[] Score;
        public int[] Level;

        public int Count;

        public HighScoreData(int count)
        {
            PlayerName = new string[count];
            Score = new int[count];
            Level = new int[count];

            Count = count;
        }
    }
}
