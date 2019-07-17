using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    static class Utility
    {
        public static Vector2 HorizontallyCenterSprite(float yPos, Rectangle boundaries, Rectangle spriteSize)
        {
            return new Vector2
            {
                Y = yPos,
                X = (boundaries.Width / 2) - (spriteSize.Width / 2) + boundaries.X
            };
        }

        public static Vector2 VerticallyCenterSprite(float xPos, Rectangle boundaries, Rectangle spriteSize)
        {
            return new Vector2
            {
                Y = (boundaries.Height / 2) - (spriteSize.Height / 2) + boundaries.Y,
                X = xPos
            };
        }

        public static Vector2 CenterSprite(Rectangle boundaries, Rectangle spriteSize)
        {
            return new Vector2
            {
                Y = (boundaries.Height / 2) - (spriteSize.Height / 2) + boundaries.Y,
                X = (boundaries.Width / 2) - (spriteSize.Width / 2) + boundaries.X
            };
        }

        public static Vector2 HorizontallyCenterText(float yPos, Rectangle boundaries, Vector2 textSize)
        {
            return new Vector2
            {
                Y = yPos,
                X = (boundaries.Width / 2) - (textSize.X / 2) + boundaries.X
            };
        }

        public static Vector2 VerticallyCenterText(float xPos, Rectangle boundaries, Vector2 textSize)
        {
            return new Vector2
            {
                Y = (boundaries.Height / 2) - (textSize.Y / 2) + boundaries.Y,
                X = xPos
            };
        }

        public static Vector2 CenterText(Rectangle boundaries, Vector2 textSize)
        {
            return new Vector2
            {
                Y = (boundaries.Height / 2) - (textSize.Y / 2) + boundaries.Y,
                X = (boundaries.Width / 2) - (textSize.X / 2) + boundaries.X
            };
        }

        public static float ScaleText(SpriteFont font, string text, Rectangle bounds)
        {
            Vector2 stringSize = font.MeasureString(text);

            float scale = Math.Min(Math.Min(bounds.Width / stringSize.X, bounds.Height / stringSize.Y), 1);
            return scale;
        }
    }
}
