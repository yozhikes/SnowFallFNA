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
    public class GameObject
    {
        private const int V = 2;
        private readonly static Random rnd = new Random();
        protected Texture2D image;
        public Vector2 position;
        private Color drawColor = Color.White;
        public float scale = float.Parse(rnd.NextDouble().ToString()), rotation = float.Parse(rnd.NextDouble().ToString());
        public float layerDepth = .5f;
        public bool active = true;
        protected Vector2 center;

        public Color DrawColor { get => drawColor; set => drawColor = value; }

        public GameObject()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void Load(ContentManager content)
        {
            CalculateCenter();
        }

        public virtual void Update(List<GameObject> objects)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (image != null && active)
            {
                spriteBatch.Draw(image, position, null, DrawColor, rotation, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
            }
        }

        private void CalculateCenter()
        {
            if (image == null)
            {
                return;
            }
            center.X = image.Width / 2;
            center.Y = image.Height / V;
        }
    }
}
