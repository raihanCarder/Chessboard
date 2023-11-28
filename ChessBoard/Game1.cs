using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.ExceptionServices;

namespace ChessBoard
{   // Raihan Carder
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tileTexture;
        Texture2D introTexture;
        int tileWidth;
        Screen screen;
        KeyboardState keyboardState;
        SpriteFont introText;
        SpriteFont instructionsIntroText;
        private SoundEffect introSong;
        SoundEffectInstance introInstance;
        enum Screen
        {
            Intro,
            Chessboard
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 640; // Size of Window
            _graphics.PreferredBackBufferHeight = 640; // Height of Window
            _graphics.ApplyChanges();
            this.Window.Title = "Christmas Chessboard";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            tileWidth = 80;
            screen = Screen.Intro;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tileTexture = Content.Load<Texture2D>("rectangle");
            introTexture = Content.Load<Texture2D>("Christmas");
            introText = Content.Load<SpriteFont>("IntroText");
            instructionsIntroText = Content.Load<SpriteFont>("IntroText");
            introSong = Content.Load<SoundEffect>("20. Fresh Emote");
            introInstance = introSong.CreateInstance();
            introInstance.IsLooped = false;
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                introInstance.Stop();
            }

            if (screen == Screen.Intro)
            {
                introInstance.Play();

                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    screen = Screen.Chessboard;
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
             
                _spriteBatch.Draw(introTexture, new Rectangle(0,0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                _spriteBatch.DrawString(introText, "Pieceless Christmas Gift", new Vector2(40, 400), Color.Black);
                _spriteBatch.DrawString(instructionsIntroText, "Press 'Space' to Continue", new Vector2(50, 450), Color.Black);
            }
            else if (screen == Screen.Chessboard)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    for (int j = 0; j < _graphics.PreferredBackBufferWidth; j += 1)
                    {

                        _spriteBatch.Draw(tileTexture, new Rectangle(i * tileWidth + (j % 2) * tileWidth, j * tileWidth, tileWidth, tileWidth), Color.Red);

                    }
                }
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}