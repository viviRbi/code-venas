using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public class Hud
    {
        public Texture2D HudObject;
        public StatusBar StatusBar;
        public StatusBar StatusBarTwo;
        public Vector2 Position;
        public string Header;
        public SpriteFont HudFont;


        public Hud(Texture2D newTexture, Vector2 newPosition)
        {
            HudObject = newTexture;
            Position = newPosition;
        }

        public Hud(string newHeader, Vector2 newPosition, SpriteFont newFont)
        {
            Header = newHeader;
            Position = newPosition;
            HudFont = newFont;
        }

        public Hud(StatusBar newStatusBar)
        {
            StatusBar = newStatusBar;
        }

        public Hud(StatusBar newStatusBar, StatusBar newStatusBarTwo)
        {
            StatusBar = newStatusBar;
            StatusBarTwo = newStatusBarTwo;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(HudObject, Position, null, color, 0.0f,Vector2.Zero,0.7f,SpriteEffects.None,0.0f);
        }

        public void DrawString(SpriteBatch spriteBatch, Color color, int updatingString)
        {
            spriteBatch.DrawString(HudFont, Header+updatingString, Position, color,0.0f,Vector2.Zero,0.7f,SpriteEffects.None,0.0f);
        }

        public void DrawBar(SpriteBatch spriteBatch)
        {
            StatusBar.Draw(spriteBatch);
            StatusBarTwo.Draw(spriteBatch);
        }
    }
}
