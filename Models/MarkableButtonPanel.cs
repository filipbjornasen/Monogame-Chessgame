using Chess.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    class MarkableButtonPanel
    {
        private List<OptionsButton> _panel;

        public MarkableButtonPanel()
        {
            _panel = new List<OptionsButton>();
        }

        public int GetMarkedIndex()
        {
            for (int i = 0; i < _panel.Count; i++)
            {
                if (_panel[i].MarkedState == OptionButtonState.Marked)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SetColor(int idx, Color clr)
        {
            _panel[idx].Color = clr;
        }

        public void SetMarked(int idx)
        {
            if (idx >= _panel.Count)
                throw new IndexOutOfRangeException();
            for (int i = 0; i < _panel.Count; i++)
            {
                if (i != idx)
                {
                    _panel[i].UnMark();
                }
            }
            _panel[idx].Mark();
        }

        public void UnmarkAll()
        {
            for (int i = 0; i < _panel.Count; i++)
            {
                _panel[i].UnMark();
            }
        }

        public Button GetMarked()
        {
            int idx = GetMarkedIndex();
            if (idx == -1)
            {
                return _panel[0];
            }
            return _panel[idx];
        }

        public void Add(OptionsButton button)
        {
            _panel.Add(button);
            _panel[_panel.Count - 1].AllowClickToUnmark = false;
        }

        public void Remove(OptionsButton ob)
        {
            _panel.Remove(ob);
            UnmarkAll();
        }

        public OptionsButton this[int index]
        {
            get
            {
                if (_panel.Count <= index)
                {
                    throw new IndexOutOfRangeException();
                }
                return _panel[index];
            }
            set
            {
                if (_panel.Count >= index)
                {
                    throw new IndexOutOfRangeException();
                }
                _panel[index] = value;
                _panel[index].AllowClickToUnmark = false;
            }
        }

        public int Count
        {
            get
            {
                return _panel.Count;
            }
        }


        public void Update(Input current, Input previous)
        {
            int marked = -1;
            for (int i = 0; i < _panel.Count; i++)
            {
                OptionsButton btn = _panel[i];
                OptionButtonState state = btn.MarkedState;
                btn.Update(current, previous);
                if (btn.MarkedState != state)
                {
                    marked = i;
                }
            }
            if (marked != -1)
            {
                for (int i = 0; i < _panel.Count; i++)
                {
                    if (i != marked)
                    {
                        _panel[i].UnMark();
                    }
                }
            }

        }

        public void Update(MouseState current, Input previous)
        {
            int marked = -1;
            for (int i = 0; i < _panel.Count; i++)
            {
                OptionsButton btn = _panel[i];
                OptionButtonState state = btn.MarkedState;
                btn.Update(current, previous);
                if (btn.MarkedState != state)
                {
                    marked = i;
                }
            }
            if (marked != -1)
            {
                for (int i = 0; i < _panel.Count; i++)
                {
                    if (i != marked)
                    {
                        _panel[i].UnMark();
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var btn in _panel)
            {
                btn.Draw(spriteBatch);
            }
        }
    }
}
