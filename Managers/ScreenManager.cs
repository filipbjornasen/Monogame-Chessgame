using Chess.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Managers
{
    class ScreenManager : IScreenManager
    {
        #region Fields

        private Stack<IScreen> _listOfScreens = new Stack<IScreen>();
        private IScreen _currentScreen;

        private DriverClass _game;

        #endregion

        #region Constructors

        public ScreenManager(IScreen startScreen, DriverClass game)
        {
            _game = game;

            _currentScreen = startScreen;
            PushScreen(_currentScreen);

            _currentScreen.Initialize(this);
        }

        #endregion

        #region Methods

        public void PushScreen(IScreen screen)
        {
            _listOfScreens.Push(screen);
        }

        public void PopScreen()
        {
            _listOfScreens.Pop();
            _currentScreen = _listOfScreens.Peek();
        }

        public void RemoveAllScreens()
        {
            while (_listOfScreens.Count > 0)
            {
                PopScreen();
            }
        }

        public void ChangeScreen()
        {
            if (_listOfScreens.Peek() != _currentScreen)
            {
                _currentScreen = _listOfScreens.Peek();

                _currentScreen.Initialize(this);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(gameTime, spriteBatch);
        }

        public void ExitGame()
        {
            _game.Exit();
        }

        public void Update(GameTime gameTime, Input curInput, Input prevInput)
        {
            _currentScreen.Update(gameTime, curInput, prevInput);
        }

        #endregion
    }
}
