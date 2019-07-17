using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Animations
{
    class ButtonAnimation
    {
        public float? Angle = null;
        public Rectangle? Bounds { get; set; } = null;
        public Color? Color { get; set; } = null;
        public bool OnlyImpactSize { get; set; } = false;

        public ButtonAnimation(float? angle, Rectangle? bounds, Color? color)
        {
            Angle = angle;
            Bounds = bounds;
            Color = color;
        }

        public ButtonAnimation(float? angle, Rectangle? bounds, Color? color, bool onlyImpactSize)
        {
            Angle = angle;
            Bounds = bounds;
            Color = color;
            OnlyImpactSize = onlyImpactSize;
        }
    }
}
