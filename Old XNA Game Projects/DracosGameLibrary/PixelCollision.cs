using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public struct PixelCollision
    {
        public struct Sprite
        {
            Texture2D texture;
            Vector2 position;
            
        }
        //public static bool PerPixelCollision(Sprite a, Sprite b) 
        //    { 
        //        // Get Color data of each Texture 
        //        //Color[] bitsA = new Color[a.Texture.Width * a.Texture.Height]; 
        //        //a.Texture.GetData(bitsA); 
	 
        //        Color[] bitsA = new Color[((AnimatedSprite)a).frameWidth * ((AnimatedSprite)a).frameHeight]; 
        //        a.Texture.GetData(0, new Rectangle(((AnimatedSprite)a).currentFrame * ((AnimatedSprite)a).frameWidth, 0, ((AnimatedSprite)a).frameWidth, ((AnimatedSprite)a).frameHeight), bitsA, 0, bitsA.Length); 
	 
        //        Color[] bitsB = new Color[b.Texture.Width * b.Texture.Height]; 
        //        b.Texture.GetData(bitsB); 
	 
        //        Rectangle test = new Rectangle(((AnimatedSprite)a).currentFrame * ((AnimatedSprite)a).frameWidth, 0, ((AnimatedSprite)a).frameWidth, ((AnimatedSprite)a).frameHeight); 
	 
        //        // Calculate the intersecting rectangle 
        //        int x1 = Math.Max(a.Bounds.X, b.Bounds.X); 
        //        int x2 = Math.Min(a.Bounds.X + ((AnimatedSprite)a).frameWidth, b.Bounds.X + b.Bounds.Width); 
	 
        //        int y1 = Math.Max(a.Bounds.Y, b.Bounds.Y); 
        //        int y2 = Math.Min(a.Bounds.Y + ((AnimatedSprite)a).frameWidth, b.Bounds.Y + b.Bounds.Height); 
	 
        //        // For each single pixel in the intersecting rectangle 
        //        for (int y = y1; y < y2; ++y) 
        //        { 
        //            for (int x = x1; x < x2; ++x) 
        //            { 
        //                // Get the color from each texture 
	 
        //                int i = (x - a.Bounds.X) + (y - a.Bounds.Y) * ((AnimatedSprite)a).frameWidth; 
        //                Color colora = bitsA[i]; 
        //                Color colorb = bitsB[(x - b.Bounds.X) + (y - b.Bounds.Y) * b.Texture.Width]; 
	 
        //                if (colora.A != 0 && colorb.A != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision 
        //                { 
        //                    return true; 
        //                } 
        //            } 
        //        } 
        //        // If no collision occurred by now, we're clear. 
        //        return false; 
        //    } 

    }
}
