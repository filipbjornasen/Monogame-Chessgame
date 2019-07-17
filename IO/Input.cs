using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.IO
{
    class Input
    {
        public KeyboardState Keyboard;
        public MouseState Mouse;

        public static Input Empty
        {
            get
            {
                return new Input();
            }
        }

        public Input(KeyboardState keyboard, MouseState mouse)
        {
            Keyboard = keyboard;
            Mouse = mouse;
        }

        public Input()
        {
            Keyboard = new KeyboardState();
            Mouse = new MouseState();
        }

        public void Add(Input input)
        {
            HashSet<Keys> hash = new HashSet<Keys>(Keyboard.GetPressedKeys());
            var keys = input.Keyboard.GetPressedKeys();
            foreach (var item in keys)
            {
                if (!hash.Contains(item))
                {
                    hash.Add(item);
                }
            }
            ButtonState leftBtn = Mouse.LeftButton;
            if (input.Mouse.LeftButton == ButtonState.Pressed)
            {
                leftBtn = ButtonState.Pressed;
            }
            ButtonState rightBtn = Mouse.RightButton;
            if (input.Mouse.RightButton == ButtonState.Pressed)
            {
                rightBtn = ButtonState.Pressed;
            }
            ButtonState midBtn = Mouse.MiddleButton;
            if (input.Mouse.MiddleButton == ButtonState.Pressed)
            {
                midBtn = ButtonState.Pressed;
            }
            Mouse = new MouseState(Mouse.X, Mouse.Y, 0, leftBtn, midBtn, rightBtn, ButtonState.Released, ButtonState.Released);
            Keyboard = new KeyboardState(hash.ToArray());
        }

        public bool Contains(Input compareInput)
        {
            var keys = compareInput.Keyboard.GetPressedKeys();
            foreach (var key in keys)
            {
                if (Keyboard.IsKeyUp(key))
                {
                    return false;
                }
            }

            if ((compareInput.Mouse.LeftButton == ButtonState.Pressed && Mouse.LeftButton != ButtonState.Pressed))
            {
                return false;
            }
            if ((compareInput.Mouse.RightButton == ButtonState.Pressed && Mouse.RightButton != ButtonState.Pressed))
            {
                return false;
            }
            if ((compareInput.Mouse.MiddleButton == ButtonState.Pressed && Mouse.MiddleButton != ButtonState.Pressed))
            {
                return false;
            }

            return true;
        }

        public void Update()
        {
            Keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            Mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        public Vector2 GetVirtualMouseLocation()
        {
            return /*Vector2.Transform(*/Mouse.Position.ToVector2()/*, Matrix.Invert(OptionsManager.Instance.Graphics.ResolutionMatrix))*/;
        }
        

        public static bool operator ==(Input inp1, Input inp2)
        {
            if (inp1.Mouse.LeftButton != inp2.Mouse.LeftButton)
            {
                return false;
            }
            if (inp1.Mouse.RightButton != inp2.Mouse.RightButton)
            {
                return false;
            }
            if (inp1.Mouse.MiddleButton != inp2.Mouse.MiddleButton)
            {
                return false;
            }

            var inp1Keys = inp1.Keyboard.GetPressedKeys();
            var inp2Keys = inp2.Keyboard.GetPressedKeys();

            if (inp1Keys.Length != inp2Keys.Length)
            {
                return false;
            }

            foreach (var item in inp1Keys)
            {
                if (inp2Keys.Contains(item) == false)
                {
                    return false;
                }
            }


            return true;
        }

        public static bool operator !=(Input inp1, Input inp2)
        {
            var inp1Keys = inp1.Keyboard.GetPressedKeys();
            var inp2Keys = inp1.Keyboard.GetPressedKeys();
            if (inp1Keys.Length != inp2Keys.Length)
            {
                return true;
            }

            foreach (var item in inp1Keys)
            {
                if (inp2Keys.Contains(item) == false)
                {
                    return true;
                }
            }
            if (inp1.Mouse.LeftButton != inp2.Mouse.LeftButton)
            {
                return true;
            }
            if (inp1.Mouse.RightButton != inp2.Mouse.RightButton)
            {
                return true;
            }
            if (inp1.Mouse.MiddleButton != inp2.Mouse.MiddleButton)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            var keys = Keyboard.GetPressedKeys();
            foreach (var key in keys)
            {
                str.Append(key).Append("+");
            }
            if (Mouse.LeftButton == ButtonState.Pressed)
            {
                str.Append("LMB+");
            }
            if (Mouse.RightButton == ButtonState.Pressed)
            {
                str.Append("RMB+");
            }
            if (Mouse.MiddleButton == ButtonState.Pressed)
            {
                str.Append("MMB");
            }

            return str.ToString().Trim(' ', '+');
        }
    }
}
