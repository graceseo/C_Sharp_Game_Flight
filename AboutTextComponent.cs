using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class AboutTextComponent : DrawableGameComponent
    {
        Game1 game;
        Texture2D about;

        private Vector2 position;
        public AboutTextComponent(Game game) : base(game)
        {
            this.game = game as Game1;
        }
        public override void Initialize()
        {
            position = new Vector2(150,200);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            about = game.Content.Load<Texture2D>("Images/aboutImage");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.Draw(about, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
    }
