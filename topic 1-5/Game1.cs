using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace topic_1_5
{

    enum Screen
    {
        Intro,
        game,
        end
        
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

        Texture2D EndScreenTexture;

        Rectangle window;

        Screen screen;

        SpriteFont textfont;
        SpriteFont EndText;

        KeyboardState keyboardstate;
        KeyboardState previusstate;

        MouseState mouseState;

        SoundEffect dirtbikeSound;
        SoundEffectInstance dirtbikeInstance;

        float rotation;
        float seconds;

        bool done;
        bool stop;
        bool rotate;

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

            bikeriderRect = new Rectangle(50, 400, 100, 99);

            motorampRect = new Rectangle(350, 350, 150, 150);

            rotation = 0.3f;

            screen = Screen.Intro;

            base.Initialize();

            seconds = 0;

            done = false;
            stop = true;
            rotate = false;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            IntroTexture = Content.Load<Texture2D>("Intro");

            bikeriderTexture = Content.Load<Texture2D>("bikerider");

            textfont = Content.Load<SpriteFont>("TextFont");

            EndText = Content.Load<SpriteFont>("EndscreenText");

            DesertTuxture = Content.Load<Texture2D>("Desert");

            motorampTexture = Content.Load<Texture2D>("motoramp");

            dirtbikeSound = Content.Load<SoundEffect>("motosoundedited");
            dirtbikeInstance = dirtbikeSound.CreateInstance();

            EndScreenTexture = Content.Load<Texture2D>("End");

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

            if(keyboardstate.IsKeyDown(Keys.Enter))
                screen = Screen.game;

            if (screen == Screen.game)
            {

                if (!done)
                    seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (bikeriderRect.X >= 300)
                {
                    stop = false;
                }

                if (stop)
                {
                    dirtbikeInstance.Play();


                    if (seconds >= 0.5)
                    {
                        rotation = -0.4f;
                        bikeriderRect.Y = 380;
                    }

                    if (seconds >= 1.5)
                    {
                        rotation = 0.3f;
                        bikeriderRect.Y = 400;
                    }
                    
                }

                if(seconds >= 0)
                {
                    bikeriderRect.X += 2;
                }

                if (bikeriderRect.X >= 740)
                {
                   
                    

                }

                else if (bikeriderRect.X >= 560)
                {
                    rotation -= 0.042f;
                    bikeriderRect.Y += 1;

                }
                else if (bikeriderRect.X >= 480)
                {
                    rotation -= 0.042f;
                    bikeriderRect.Y += -1;

                }

                else if (bikeriderRect.X >= 365 )
                {
                    bikeriderRect.Y += -1;
                    rotation -= 0.02f;
                }
                
                
                
                if (rotation >= 0.3f)
                {
                    rotation = 0.3f;
                }

                if (dirtbikeInstance.State == SoundState.Stopped)
                    screen = Screen.end;




               

            }

            if (screen == Screen.end)
            {
                if (keyboardstate.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
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
            if (screen == Screen.end)
            {
                _spriteBatch.Draw(EndScreenTexture, window, Color.White);
                _spriteBatch.DrawString(EndText, "press Enter to close", new Vector2(200,250), Color.Black);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
