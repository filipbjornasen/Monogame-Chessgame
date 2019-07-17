using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Animations;
using Chess.IO;
using Chess.Managers;
using Chess.Models;
using Chess.Models.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.Screens
{
    class GameScreen : IScreen
    {
        ScreenManager screenManager;

        Board board;


        public void Initialize(ScreenManager screenManager)
        {
            this.screenManager = screenManager;

            board = new Board();
        }

        public void Update(GameTime gameTime, Input curInput, Input prevInput)
        {
            board.Update(gameTime, curInput, prevInput);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            board.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}