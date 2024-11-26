using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace topic_1_5
{

    enum Screen
    {
        Intro,
        game
        
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D IntroTexture;

        Texture2D bikeriderTexture;
        Rectangle bikeriderRect;

        Texture2D motorampTexture;
        Rectangle motorampRect;

        Texture2D DesertTuxture;

        Rectangle window;

        Screen screen;

        SpriteFont textfont;

        KeyboardState keyboardstate;
        KeyboardState previusstate;

        MouseState mouseState;

        SoundEffect dirtbikeSound;
        SoundEffectInstance dirtbikeInstance;

        float rotation;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0,0,800,600);

            bikeriderRect = new Rectangle(100, 400, 100, 99);

            motorampRect = new Rectangle(600, 350, 150, 150);

            rotation = 0.3f;

            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            IntroTexture = Content.Load<Texture2D>("Intro");

            bikeriderTexture = Content.Load<Texture2D>("bikerider");

            textfont = Content.Load<SpriteFont>("TextFont");

            DesertTuxture = Content.Load<Texture2D>("Desert");

            motorampTexture = Content.Load<Texture2D>("motoramp");

            dirtbikeSound = Content.Load<SoundEffect>("dirtbikesound");
            dirtbikeInstance = dirtbikeSound.CreateInstance();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            previusstate = keyboardstate;
            keyboardstate = Keyboard.GetState();
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";


            if (keyboardstate.IsKeyDown(Keys.Enter))
            {
                screen = Screen.game;
                bikeriderRect.X += 1;
                dirtbikeInstance.Play();
                dirtbikeInstance.Resume();

                if (keyboardstate.IsKeyDown(Keys.Space))
                {
                    rotation = -0.4f;
                    bikeriderRect.Y = 380;
                }
            }

            if (previusstate.IsKeyUp(Keys.Space))
            {
                rotation = 0.3f;
                bikeriderRect.Y = 400;
            }

            if (keyboardstate.IsKeyUp(Keys.Enter))
            {
                dirtbikeInstance.Pause();
            }

                

            // TODO: Add your update logic here



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(IntroTexture, window, Color.White);
                _spriteBatch.DrawString(textfont, "Press Enter to continue", new Vector2(25, 200), Color.Black);
            }
            if (screen == Screen.game)
            {
                _spriteBatch.Draw(DesertTuxture, window, Color.White);
                _spriteBatch.Draw(motorampTexture,motorampRect, Color.White);
                _spriteBatch.Draw(bikeriderTexture, bikeriderRect, null, Color.White, rotation, new Vector2(bikeriderTexture.Width/2,bikeriderTexture.Height/2), SpriteEffects.None, 0f);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
