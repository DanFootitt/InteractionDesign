using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using System.Threading;

namespace InteractionDesign_v1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Mouse mouse;
        Texture2D man;
        Texture2D chestbar;
        Texture2D bar;
        Vector2 barpos;
        ClickableButton mouth;
        ClickableButton shoulder;
        ClickableButton chest;
        ClickableButton nose;
        ClickableButton undo;
        ClickableButton phone;
        String lastClick;
        SpriteFont test;
        Stopwatch stopwatch;
        String elapsedTime;
        bool isMovingLeft = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player();
            mouse = new Mouse(Content, "Images\\cursor");
            man = Content.Load<Texture2D>("Images\\bloke");
            chestbar = Content.Load<Texture2D>("Images\\chestbar");
            bar = Content.Load<Texture2D>("Images\\bar");
            barpos = new Vector2(200, 318);
            shoulder = new ClickableButton(Content, "Images\\circle", new Vector2(300, 150), player, "Shoulder", (int)ClickableObject.ButtonType.SIMPLE);
            chest = new ClickableButton(Content, "Images\\circle", new Vector2(400, 200), player, "Chest", (int)ClickableObject.ButtonType.SIMPLE);
            nose = new ClickableButton(Content, "Images\\circle", new Vector2(150, 200), player, "Nose", (int)ClickableObject.ButtonType.SIMPLE);
            undo = new ClickableButton(Content, "Images\\undo", new Vector2(680, 380), player, "Undo", (int)ClickableObject.ButtonType.UNDO);
            mouth = new ClickableButton(Content, "Images\\circle", new Vector2(200, 200), player, "Mouth", (int)ClickableObject.ButtonType.MOVEABLE);
            phone = new ClickableButton(Content, "Images\\phone", new Vector2(10, 350), player, "Phone", (int)ClickableObject.ButtonType.SIMPLE);
            test = Content.Load<SpriteFont>("test");
            stopwatch = new Stopwatch();
            stopwatch.Start();
            
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            TimeSpan ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds/10);

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (player.actions.Count > 1)
            {
                lastClick = player.actions[player.actions.Count - 1];
            }
            else {
                lastClick = "NULL";
            }

            mouse.Update();
            mouth.Update(gameTime, mouse);
            shoulder.Update(gameTime, mouse);
            chest.Update(gameTime, mouse);
            nose.Update(gameTime, mouse);
            undo.Update(gameTime, mouse);
            phone.Update(gameTime, mouse);
            player.update(gameTime);
            
            
            if (player.isChestPressed)
            {
                KeyboardState kbstate = Keyboard.GetState();

                if (isMovingLeft)
                {
                    barpos.X += 6.0f;
                }
                
                if (!isMovingLeft){
                    barpos.X -= 6.0f;
                }

                if (barpos.X <= 200){
                    isMovingLeft = true;
                    Console.Write(barpos.X);
                }
                
                if (barpos.X >= 200 + chestbar.Width){
                    isMovingLeft = false;
                    Console.Write(barpos.X);
                }

            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            
            // TODO: Add your drawing code here
            
            
            spriteBatch.Begin();
            spriteBatch.Draw(man, new Rectangle(0, 0, man.Width, man.Height), Color.White);
            spriteBatch.DrawString(test, "Last Click : " + lastClick, new Vector2(10, 30), Color.Black);
            spriteBatch.DrawString(test, "Elapsed Time : " + elapsedTime, new Vector2(10, 0), Color.Black);
            if (player.isShowingInfo)
            {
                spriteBatch.DrawString(test, "Hint : " + player.info[0], new Vector2(100, 400), Color.Black);
            }
            spriteBatch.End();

            shoulder.Draw(spriteBatch);
            chest.Draw(spriteBatch);
            nose.Draw(spriteBatch);
            mouth.Draw(spriteBatch);
            undo.Draw(spriteBatch);
            phone.Draw(spriteBatch);
            
            if (player.isChestPressed) {
                spriteBatch.Begin();
                spriteBatch.Draw(chestbar, new Rectangle(200, 320, chestbar.Width, chestbar.Height), Color.White);
                spriteBatch.Draw(bar, new Rectangle((int)barpos.X, (int)barpos.Y, bar.Width, bar.Height), Color.White);
                spriteBatch.End();
            }

            
            mouse.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
