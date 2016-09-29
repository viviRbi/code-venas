using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace DracosGameLibrary
{
    public class MusicLoader
    {
        ContentManager content;
        public List<Song> musicList = new List<Song>();
        private Song music;
        private Random random = new Random();
        private int maxSongs;
        private String location;

        public MusicLoader(ContentManager content, String newLocation, int newMaxSongs)
        {
            this.content = content;
            this.maxSongs = newMaxSongs;

            for (int i = 1; i < maxSongs; i++)
            {
                location = newLocation + i;
                music = content.Load<Song>(location);
                musicList.Add(music);
            }
        }

        public void PlayMusic()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(musicList[random.Next(0, maxSongs-1)]);
        }
    }
}
