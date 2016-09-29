using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public class StatusBar
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;
        int rectWidth;
        int rectHeightDiv;

        public StatusBar(Texture2D newTexture,Vector2 newPosition,int newRecWidth,int newRectHeightDiv)
        {
            texture = newTexture;
            position = newPosition;
            rectWidth = newRecWidth/5;
            if (newRectHeightDiv != 0)
                rectHeightDiv = newRectHeightDiv;
            else
                rectHeightDiv = 1;

            initRect();
        }

        public StatusBar(Texture2D newTexture, Vector2 newPosition, int newRecWidth, int newRectHeightDiv,int newRecWidthDiv)
        {
            texture = newTexture;
            position = newPosition;
            rectWidth = newRecWidth / newRecWidthDiv;
            if (newRectHeightDiv != 0)
                rectHeightDiv = newRectHeightDiv;
            else
                rectHeightDiv = 1;

            initRect();
        }

        private void initRect()
        {
            rectangle = new Rectangle(0, 0, rectWidth, texture.Height/rectHeightDiv);
        }

        public void DamageStatusBar(int damage) 
        {
            rectangle.Width -= damage;
        }

        public void DamageStatusBarH(int damage)
        {
            rectangle.Height -= damage;
        }

        public void IncreaseStatusBar(int increment)
        {
            rectangle.Width += increment;
        }

        public void IncreaseStatusBarH(int increment)
        {
            rectangle.Height += increment;
        }

        public void UpdateStatusBar(int value,int divide)
        {
            rectangle.Width = value/divide;
        }

        public void UpdateStatusBar(int value)
        {
            rectangle.Width = value;
        }

        public void UpdateStatusBarH(int value)
        {
            rectangle.Height = value;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, Color.White);
        }

    }
}
