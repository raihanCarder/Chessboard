using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.ExceptionServices;

namespace ChessBoard
{   // Raihan C
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tileTexture;
        int tileWidth;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.Window.Title = "Christmas Chessboard";
            _graphics.PreferredBackBufferWidth = 640; // Size of Window
            _graphics.PreferredBackBufferHeight = 640; // Height of Window
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            tileWidth = 80;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tileTexture = Content.Load<Texture2D>("rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            for (int i = 0; i < 8; i+=2)
            {
                for (int j = 0; j < _graphics.PreferredBackBufferWidth; j += 1)
                {
                    
                    _spriteBatch.Draw(tileTexture, new Rectangle(i * tileWidth + (j % 2) * tileWidth, j * tileWidth, tileWidth , tileWidth), Color.Red);
                    
                }
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}