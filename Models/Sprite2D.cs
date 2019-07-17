using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    class Sprite2D
    {
        #region Members
        public Color Color;
        public Texture2D Texture;

        float _angle;
        public float Angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
            }
        }
        private Vector2 _location;
        public Vector2 Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                _rectangle.X = (int)_location.X;
                _rectangle.Y = (int)_location.Y;
            }
        }
        private Rectangle _rectangle;
        public Rectangle Bounds
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
                _location = _rectangle.Location.ToVector2();
            }
        }

        public int Width { get => _rectangle.Width; set => _rectangle.Width = value; }

        public int Height { get => _rectangle.Height; set => _rectangle.Height = value; }

        public bool Show { get; set; } = true;
        #endregion

        #region Constructors
        public Sprite2D(Texture2D texture) : this(texture, Rectangle.Empty)
        { }

        public Sprite2D(Texture2D texture, Rectangle rectangle) : this(texture, rectangle, Color.White)
        { }

        public Sprite2D(Texture2D texture, Vector2 location)
        {
            this.Texture = texture;
            this._rectangle = Rectangle.Empty;
            this.Location = location;
            this.Color = Color.White;
        }

        public Sprite2D(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this._location = Vector2.Zero;
            this.Bounds = rectangle;
            this.Color = color;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Show)
            {
                Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
                Rectangle destRect = new Rectangle(_rectangle.X + _rectangle.Width / 2, _rectangle.Y + _rectangle.Height / 2, _rectangle.Width, _rectangle.Height);
                spriteBatch.Draw(Texture, destRect, null, Color, Angle, origin, SpriteEffects.None, 0f);
            }
        }

        public void HorizontallyCenter(Rectangle boundaries, float yLocation)
        {
            Location = new Vector2((boundaries.Width / 2) - (Bounds.Width / 2) + boundaries.X, yLocation);
        }

        public void VerticallyCenter(Rectangle boundaries, float xLocation)
        {
            Location = new Vector2(xLocation, (boundaries.Height / 2) - (Bounds.Height / 2) + boundaries.Y);
        }

        public void Center(Rectangle boundaries)
        {
            Location = new Vector2(
(boundaries.Width / 2) - (Bounds.Width / 2) + boundaries.X,
(boundaries.Height / 2) - (Bounds.Height / 2) + boundaries.Y);

        }

        public void Center(Rectangle bounds, Vector2 offSet)
        {
            Location = new Vector2(
(bounds.Width / 2) - (Bounds.Width / 2) + bounds.X,
(bounds.Height / 2) - (Bounds.Height / 2) + bounds.Y);
            Location += offSet;
        }

        public bool Contains(Vector2 pos)
        {
            if (Angle == 0)
                return Bounds.Contains(pos);
            Vector2 origin = _rectangle.Center.ToVector2();
            Vector2 virtualPos = Vector2.Transform(pos - origin, Matrix.CreateRotationZ(-Angle)) + origin;

            if (_rectangle.Contains(virtualPos))
                return true;
            return false;
        }

        public bool Contains(Point pos)
        {
            return Contains(pos.ToVector2());
        }
        #endregion
    }
}
