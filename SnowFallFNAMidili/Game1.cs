using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Texture2D fon;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random rnd = new Random();
        public List<GameObject> objects = new List<GameObject>();
        private double seconds = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }


        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            fon = TextureLoader.Load("fon", Content);

            LoadLevel();
        }


        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            UpdateObjects();
             if (Input.MouseLeftClicked())
             {
                 objects.Clear();
                 LoadLevel();
             }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            DrawObjects();
            spriteBatch.Draw(fon, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            seconds += gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void LoadLevel()
        {
            for (int i = 0; i < 2000; i++)
                objects.Add(new Snow(new Vector2(rnd.Next(0, 1280), rnd.Next(-1880, -780))));
            LoadObjects();
        }

        public void LoadObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Initialize();
                objects[i].Load(Content);
            }
        }

        public void UpdateObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(objects);
            }
        }

        public void DrawObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }
    } 
}
