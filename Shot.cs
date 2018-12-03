using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class Shot
    {
        Game1 game;
        Rectangle rectangle;
        Texture2D fighterShot;


        public Shot(Game1 game, Vector2 startLocation)
        {
            this.game = game;
            fighterShot = game.Content.Load<Texture2D>("Images/fighterShot");
            rectangle = new Rectangle((int)startLocation.X, (int)startLocation.Y, fighterShot.Width, fighterShot.Height);

        }

        public void Update()
        {
            rectangle.Y -= 10;

            //foreach (Meteor meteor in game.meteorList)
            //{
            //    if (rectangle.Intersects(meteor.rectangle))
            //    {
            //        meteor.Hit();
            //    }
            //}

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (rectangle.Y > fighterShot.Height * -1)
            {
                spriteBatch.Draw(fighterShot, rectangle, Color.White);

            }
        }

    }
}
