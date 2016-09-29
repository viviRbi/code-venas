using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Storage;
using System.Xml.Serialization;

namespace DracosGameLibrary
{
    public class HighScore
    {
        private int currentHighScore;
        private int pastHighScore;
        public readonly string HighScoresFilename = "highScores.lst";

        public HighScore()
        {
            Initialize();
        }

        public static void SaveHighScores(HighScoreData data, string filename)
        {
            string fullpath = Path.Combine(StorageContainer.TitleLocation, filename);

            FileStream stream = File.Open(fullpath, FileMode.Create);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                serializer.Serialize(stream, data);

            }
            finally
            {
                stream.Close();
            }
        }

        public static HighScoreData LoadHighScores(string filename)
        {
            HighScoreData data;

            string fullpath = Path.Combine(StorageContainer.TitleLocation, filename);

            FileStream stream = File.Open(fullpath, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                data = (HighScoreData)serializer.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }

            return (data);
        }

        public void SaveHighScore(PlayerInfo player)
        {
            // Create the data to save
            HighScoreData data = LoadHighScores(HighScoresFilename);

            int scoreIndex = -1;
            for (int i = 0; i < data.Count; i++)
            {
                if (player.score > data.Score[i])
                {
                    scoreIndex = i;
                    break;
                }
            }

            if (scoreIndex > -1)
            {
                //New high score found ... do swaps
                for (int i = data.Count - 1; i > scoreIndex; i--)
                {
                    data.PlayerName[i] = data.PlayerName[i - 1];
                    data.Score[i] = data.Score[i - 1];
                    data.Level[i] = data.Level[i - 1];
                }

                data.PlayerName[scoreIndex] = player.name; //Retrieve User Name Here
                data.Score[scoreIndex] = player.score;
                data.Level[scoreIndex] = player.stageLevel;

                SaveHighScores(data, HighScoresFilename);
            }
        }

        protected void Initialize()
        {
            // Get the path of the save game
            string fullpath = Path.Combine(StorageContainer.TitleLocation, HighScoresFilename);

            // Check to see if the save exists
            if (!File.Exists(fullpath))
            {
                //If the file doesn't exist, make a fake one...
                // Create the data to save
                HighScoreData data = new HighScoreData(10);
                data.PlayerName[0] = "Malefis Shadow";
                data.Level[0] = 20;
                data.Score[0] = 10000000;

                data.PlayerName[1] = "Demisa";
                data.Level[1] = 10;
                data.Score[1] = 5000000;

                data.PlayerName[2] = "Not Draco";
                data.Level[2] = 8;
                data.Score[2] = 1000000;

                data.PlayerName[3] = "Loser";
                data.Level[3] = 5;
                data.Score[3] = 500000;

                data.PlayerName[4] = "Crushed Dreams";
                data.Level[4] = 1;
                data.Score[4] = 100000;

                data.PlayerName[5] = "Cannon Fodder";
                data.Level[5] = 1;
                data.Score[5] = 50000;

                data.PlayerName[6] = "Waste of Space";
                data.Level[6] = 1;
                data.Score[6] = 10000;

                data.PlayerName[7] = "Sad";
                data.Level[7] = 1;
                data.Score[7] = 1000;

                data.PlayerName[8] = "Impossible";
                data.Level[8] = 1;
                data.Score[8] = 10;

                data.PlayerName[9] = "---";
                data.Level[9] = 1;
                data.Score[9] = 0;

                SaveHighScores(data, HighScoresFilename);
            }
        }
    }
}
