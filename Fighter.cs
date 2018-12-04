using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class Fighter : DrawableGameComponent
    {
        Game1 game;

        static public Rectangle rectangle; //for get shot from enemies
        static public bool isHit = false;//for get shot from enemies
        static public int heart = 3; //for fighter's heart

        Texture2D fighterIdle;
        Texture2D fighterLeft;
        Texture2D fighterRight;
        Texture2D fighterCurrent;
        Texture2D fighterExpload;

        Vector2 fighterPosition;
        const int SPEED = 5;
        List<FighterShot> ShotList;
        bool shotEnable = true;

        int timerSinceHit;

        public Fighter(Game1 game) : base(game)
        {
            this.game = game;
            ShotList = new List<FighterShot>();
        }
        protected override void LoadContent()
        {
            fighterIdle = game.Content.Load<Texture2D>("Images/fighter");
            fighterLeft = game.Content.Load<Texture2D>("Images/fighterLeft");
            fighterRight = game.Content.Load<Texture2D>("Images/fighterRight");
            fighterExpload = game.Content.Load<Texture2D>("Images/fighterExplosion");

            fighterPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - fighterIdle.Width / 2,
                                        GraphicsDevice.Viewport.Height - fighterIdle.Height);
            fighterCurrent = fighterIdle;
            rectangle = new Rectangle((int)fighterPosition.X, (int)fighterPosition.Y, fighterCurrent.Width, fighterCurrent.Height);
            base.LoadContent();
        }

        /// <summary>
        /// the main Update method.
        ///It calls FighterUpdate for updating Fighter Character by checking some condistions.
        ///a fighter only work if it has enough heart and not get hit.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (!isHit && heart>0)
            {
                FighterUpdate();
            }
            else if(isHit && heart>0)
            {
                FighterUpdate(); //#####################
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();

            if (!isHit)
            {
                game.spriteBatch.Draw(fighterCurrent, fighterPosition, Color.White);
                foreach (FighterShot shot in ShotList)
                {
                    shot.Draw(game.spriteBatch);
                }
            }
            else
            {
                timerSinceHit++;
                if (timerSinceHit < 30)
                {
                    game.spriteBatch.Draw(fighterExpload, fighterPosition, Color.White);
                }
            }
            game.spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// this method is part of the Update method.
        /// when only a fighter live and is not hit, this method is called.
        /// When a fighter moves, it shouldn't move into outside this window, 
        /// so every direction keyboards' action calculate this fighter's position and the window size
        /// </summary>
        public void FighterUpdate()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && fighterPosition.X > 0)
            {
                fighterCurrent = fighterLeft;
                fighterPosition.X -= SPEED;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && fighterPosition.X < (Game1.WINDOW_WIDTH - fighterIdle.Width))
            {
                fighterCurrent = fighterRight;
                fighterPosition.X += SPEED;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                fighterCurrent = fighterIdle;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                fighterCurrent = fighterIdle;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && fighterPosition.Y > 0)
            {
                fighterCurrent = fighterIdle;
                fighterPosition.Y -= SPEED;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && fighterPosition.Y < (Game1.WINDOW_HEIGHT - fighterIdle.Height))
            {
                fighterCurrent = fighterIdle;
                fighterPosition.Y += SPEED;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && shotEnable)
            {
                ShotList.Add(new FighterShot(game, new Vector2(fighterPosition.X + (fighterIdle.Width -90), fighterPosition.Y)));
                ShotList.Add(new FighterShot(game, new Vector2(fighterPosition.X + (fighterIdle.Width-20), fighterPosition.Y)));
                shotEnable = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                shotEnable = true;
            }
            //if ractagle is not updated, intersect doesn't work
            rectangle.X = (int)fighterPosition.X;
            rectangle.Y = (int)fighterPosition.Y;

            foreach (FighterShot shot in ShotList)
            {
                shot.Update();
            }
        }
    }
}
