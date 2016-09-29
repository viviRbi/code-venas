using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DracosGameLibrary
{
    public struct Circle
    {
        /// <summary>
        /// Center position of the circle.
        /// </summary>
        public Vector2 Center;

        /// <summary>
        /// Radius of the circle.
        /// </summary>
        public float Radius;

        /// <summary>
        /// Constructs a new circle.
        /// </summary>
        public Circle(Vector2 position, float radius)
        {
            Center = position;
            Radius = radius;
        }

        /// <summary>
        /// Determines if a circle intersects a rectangle.
        /// </summary>
        /// <returns>True if the circle and rectangle overlap. False otherwise.</returns>
        public bool Intersects(Rectangle rectangle)
        {
            Vector2 v = new Vector2(MathHelper.Clamp(Center.X, rectangle.Left, rectangle.Right),
                                    MathHelper.Clamp(Center.Y, rectangle.Top, rectangle.Bottom));

            Vector2 direction = Center - v;
            float distanceSquared = direction.LengthSquared();

            return ((distanceSquared > 0) && (distanceSquared < Radius * Radius));
        }

        public bool Intersects(Circle otherCircle)
        {
            return ((otherCircle.Center - Center).Length() < (otherCircle.Radius - Radius));
        }

        public bool IntersectsCenter(Circle otherCircle)
        {
            return (otherCircle.Center == Center);
        }

        public bool Contains(Vector2 point)
        {
            return ((point - Center).Length() <= Radius);
        }
    }
}
