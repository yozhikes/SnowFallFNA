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
        private Texture2D fon;
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private readonly Random rnd = new Random();
        public List<GameObject> objects = new List<GameObject>();
        private int n = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Snowfall";
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
            StopStart();
            UpdateObjects();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            DrawObjects();
            spriteBatch.Draw(fon, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void LoadLevel()
        {
            for (var i = 0; i < 500; i++)
            {
                objects.Add(new Snow(new Vector2(rnd.Next(0, 1280), rnd.Next(-780, -50))));
            }
            LoadObjects();
        }

        public void LoadObjects()
        {
            for (var i = 0; i < objects.Count; i++)
            {
                objects[i].Initialize();
                objects[i].Load(Content);
            }
        }

        public void UpdateObjects()
        {
            if (n == 0)
            {
                for (var i = 0; i < objects.Count; i++)
                {
                    objects[i].Update(objects);
                    objects[i].position.Y += 1 + objects[i].scale * 5;
                    if (objects[i].position.Y <= 720)
                    {
                        continue;
                    }
                    objects[i].position.Y = -50;
                }
            }
        }

        public void DrawObjects()
        {
            for (var i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }

        private void StopStart()
        {
            if (Input.MouseLeftClicked())
            {
                n++;
                if (n == 2)
                {
                    n = 0;
                }
            }
        }
    }
}
