using Chess.IO;
using Chess.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    interface IScreen
    {
        void Initialize(ScreenManager screenManager);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        void Update(GameTime gameTime, Input curInput, Input prevInput);
    }

    interface IScreenManager
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        void Update(GameTime gameTime, Input curInput, Input prevInput);

        void ChangeScreen();

        void RemoveAllScreens();

        void PopScreen();

        void PushScreen(IScreen screen);

        void ExitGame();
    }
}
