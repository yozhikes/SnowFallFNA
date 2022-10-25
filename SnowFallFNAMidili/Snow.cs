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
    public class Snow:GameObject
    {
        static Random rnd = new Random();
        public Snow(Vector2 inputPosition)
        {

            position = inputPosition;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("snow", content);
            base.Load(content);
        }

        public override void Update(List<GameObject> objects)
        {
            CheckInput();
            base.Update(objects);
        }

        private void CheckInput()
        {
            position.Y += rnd.Next(15, 30);
        }
    }
}
