using Chess.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Chess.IO;

namespace Chess.Models
{
    enum OptionButtonState
    {
        Unmarked,
        Marked
    }

    class OptionsButton : Button
    {
        public OptionButtonState MarkedState { get; private set; }

        public ButtonAnimation MarkAnimation { get; set; }
        public ButtonAnimation UnMarkAnimation { get; set; }

        public event EventHandler Marked;
        public event EventHandler UnMarked;

        public bool AllowClickToUnmark = true;

        public OptionsButton(Sprite2D sprite) : base(sprite)
        {
        }

        public override void Update(Input currentInput, Input previousInput)
        {
            if (Contains(currentInput.GetVirtualMouseLocation()))
            {
                if (currentInput.Mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    State = ButtonCondition.Pressed;
                    if (ClickAnimation != null) Animate(ClickAnimation);
                    if (AllowClickToUnmark && MarkedState == OptionButtonState.Marked)
                    {
                        UnMark();
                    }
                    else if (MarkedState != OptionButtonState.Marked)
                    {
                        Mark();
                    }
                    OnClick(EventArgs.Empty);
                }
                else if (State != ButtonCondition.Hovered && MarkedState != OptionButtonState.Marked)
                {
                    if (State == ButtonCondition.None)
                    {
                        if (HoverAnimation != null) Animate(HoverAnimation);
                        OnHover(EventArgs.Empty);
                    }
                    State = ButtonCondition.Hovered;
                }
            }
            else if (State != ButtonCondition.None && MarkedState != OptionButtonState.Marked)
            {
                if (UnHoverAnimation != null) Animate(UnHoverAnimation);
                OnUnHover(EventArgs.Empty);
                State = ButtonCondition.None;
            }
        }

        public override void Update(MouseState currentInput, Input previousInput)
        {
            if (Contains(currentInput.Position))
            {
                if (currentInput.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    State = ButtonCondition.Pressed;
                    if (ClickAnimation != null) Animate(ClickAnimation);
                    if (AllowClickToUnmark && MarkedState == OptionButtonState.Marked)
                    {
                        UnMark();
                    }
                    else if (MarkedState != OptionButtonState.Marked)
                    {
                        Mark();
                    }
                    OnClick(EventArgs.Empty);
                }
                else if (State != ButtonCondition.Hovered && MarkedState != OptionButtonState.Marked)
                {
                    if (State == ButtonCondition.None)
                    {
                        if (HoverAnimation != null) Animate(HoverAnimation);
                        OnHover(EventArgs.Empty);
                    }
                    State = ButtonCondition.Hovered;
                }
            }
            else if (State != ButtonCondition.None && MarkedState != OptionButtonState.Marked)
            {
                if (UnHoverAnimation != null) Animate(UnHoverAnimation);
                OnUnHover(EventArgs.Empty);
                State = ButtonCondition.None;
            }
        }

        public void Mark()
        {
            if (MarkAnimation != null) Animate(MarkAnimation);
            MarkedState = OptionButtonState.Marked;
            OnMarked(EventArgs.Empty);

        }

        public void UnMark()
        {
            if (UnMarkAnimation != null) Animate(UnMarkAnimation);
            MarkedState = OptionButtonState.Unmarked;
            OnUnMarked(EventArgs.Empty);
        }

        protected virtual void OnMarked(EventArgs e)
        {
            EventHandler handler = Marked;
            handler?.Invoke(this, e);
        }

        protected virtual void OnUnMarked(EventArgs e)
        {
            EventHandler handler = UnMarked;
            handler?.Invoke(this, e);
        }
    }
}
