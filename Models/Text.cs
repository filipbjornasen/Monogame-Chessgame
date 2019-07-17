using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    class Text
    {
        #region Fields

        public float scale = 1f;

        public string Body { get; set; } = "";

        public Vector2 Position { get; set; } = Vector2.Zero;

        public SpriteFont Font { get; set; }

        public Color Color { get; set; } = Color.Black;

        #endregion

        #region Methods

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(Font, Body, Position, Color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void VerticallyCenterText(float xPos, Rectangle boundaries)
        {
            var textSize = Font.MeasureString(Body);
            textSize.Y *= scale;
            Position = Utility.VerticallyCenterText(xPos, boundaries, textSize);
        }

        public void HorizontallyCenterText(float yPos, Rectangle boundaries)
        {
            var textSize = Font.MeasureString(Body);
            textSize.X *= scale;
            Position = Utility.HorizontallyCenterText(yPos, boundaries, textSize);
        }

        public void CenterText(Rectangle boundaries)
        {
            var textSize = Font.MeasureString(Body);
            textSize *= scale;
            Position = Utility.CenterText(boundaries, textSize);
        }

        public void ScaleText(Rectangle bounds)
        {
            scale = Utility.ScaleText(Font, Body, bounds);
        }

        #endregion
    }
}
