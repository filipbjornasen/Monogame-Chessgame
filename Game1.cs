using Chess.IO;
using Chess.Managers;
using Chess.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Chess
{
    // A simple program to play 1v1 chess.
    // The program tells all avalible possible moves and contains all 
    // normal and special moves in chess aswell as restricts pieces from doing illegal moves.
    public class DriverClass : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Random Random = new Random(); //Static since new seed is generated with current time

        ScreenManager screenManager;

        Input currentInput;
        Input previousInput;

        public DriverClass()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Constants.TILESIZE * 8;
            graphics.PreferredBackBufferHeight = Constants.TILESIZE * 8;
            graphics.ApplyChanges();

            Window.Title = "Chess";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            previousInput = new Input();
            currentInput = new Input();

            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentService.Instance.LoadContent(this.Content, GraphicsDevice, spriteBatch);

            screenManager = new ScreenManager(new GameScreen(), this);
        }

        protected override void UnloadContent()
        { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            screenManager.ChangeScreen();

            previousInput.Keyboard = currentInput.Keyboard;
            previousInput.Mouse = currentInput.Mouse;

            currentInput.Update();

            screenManager.Update(gameTime, currentInput, previousInput);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            screenManager.Draw(gameTime,spriteBatch);

            base.Draw(gameTime);
        }
    }
}
