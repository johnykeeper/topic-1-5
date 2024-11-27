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

            bikeriderRect = new Rectangle(50, 400, 100, 99);

            motorampRect = new Rectangle(350, 350, 150, 150);

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
                bikeriderRect.X += 2;
                dirtbikeInstance.Play();
                dirtbikeInstance.Resume();

                if (keyboardstate.IsKeyDown(Keys.Space))
                {
                    rotation = -0.4f;
                    bikeriderRect.Y = 380;
                }

                if (previusstate.IsKeyUp(Keys.Space))
                {
                    rotation = 0.3f;
                    bikeriderRect.Y = 400;
                }
            }





            if (keyboardstate.IsKeyUp(Keys.Enter))
            {
                dirtbikeInstance.Pause();
            }

            if (bikeriderRect.X >= 350)
            {
                rotation = 0.3f;
                bikeriderRect.Y = 400;
            }

            if (bikeriderRect.X >= 355)
            {
                rotation = 0.2f;
                bikeriderRect.Y = 397;
            }


            if (bikeriderRect.X >= 360)
            {
                rotation = -0.0f;
                bikeriderRect.Y = 394;
            }

            if (bikeriderRect.X >= 365)
            {
                rotation = -0.1f;
                bikeriderRect.Y = 390;
            }

            if (bikeriderRect.X >= 380)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 389;
            }

            if (bikeriderRect.X >= 390)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 388;
            }

            if (bikeriderRect.X >= 400)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 382;
            }

            if (bikeriderRect.X >= 415)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 375;
            }

            if (bikeriderRect.X >= 425)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 368;
            }

            if (bikeriderRect.X >= 430)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 365;
            }

            if (bikeriderRect.X >= 445)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 358;
            }

            if (bikeriderRect.X >= 450)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 350;
            }

            if (bikeriderRect.X >= 468)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 344;
            }

            if (bikeriderRect.X >= 475)
            { 
                rotation = -0.2f;
                bikeriderRect.Y = 335;
            }

            if (bikeriderRect.X >= 480)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 325;
            }

            if (bikeriderRect.X >= 490)
            {
                rotation = -0.2f;
                bikeriderRect.Y = 315;
            }

            if (bikeriderRect.X >= 500)
            {
                rotation = -0.15f;
                bikeriderRect.Y = 310;
            }

            if (bikeriderRect.X >= 510)
            {
                rotation = -0.05f;
                bikeriderRect.Y = 305;
            }

            if (bikeriderRect.X >= 520)
            {
                rotation = 0.05f;
                bikeriderRect.Y = 295;
            }

            if (bikeriderRect.X >= 525)
            {
                rotation = 0.1f;
                bikeriderRect.Y = 292;
            }

            if (bikeriderRect.X >= 535)
            {
                rotation = 0.15f;
                bikeriderRect.Y = 290;
            }

            if (bikeriderRect.X >= 545)
            {
                rotation = 0.22f;
                bikeriderRect.Y = 288;
            }

            if (bikeriderRect.X >= 555)
            {
                rotation = 0.25f;
                bikeriderRect.Y = 290;
            }

            if (bikeriderRect.X >= 565)
            {
                rotation = 0.25f;
                bikeriderRect.Y = 290;
            }

            if (bikeriderRect.X >= 570)
            {
                rotation = 0.25f;
                bikeriderRect.Y = 290;
            }

            if (bikeriderRect.X >= 575)
            {
                rotation = 0.3f;
                bikeriderRect.Y = 295;
            }

            if (bikeriderRect.X >= 585)
            {
                rotation = 0.4f;
                bikeriderRect.Y = 310;
            }

            if (bikeriderRect.X >= 595)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 320;
            }

            if (bikeriderRect.X >= 605)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 330;
            }

            if (bikeriderRect.X >= 620)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 340;
            }

            if (bikeriderRect.X >= 630)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 350;
            }

            if (bikeriderRect.X >= 640)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 360;
            }

            if (bikeriderRect.X >= 650)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 360;
            }

            if (bikeriderRect.X >= 665)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 370;
            }

            if (bikeriderRect.X >= 675)
            {
                rotation = 0.5f;
                bikeriderRect.Y = 380;
            }

            if (bikeriderRect.X >= 690)
            {
                rotation = 0.4f;
                bikeriderRect.Y = 390;
            }

            if (bikeriderRect.X >= 705)
            {
                rotation = 0.3f;
                bikeriderRect.Y = 400;
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
