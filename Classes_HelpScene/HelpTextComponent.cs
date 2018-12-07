using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class HelpTextComponent : DrawableGameComponent
    {
        Game1 game;
        Texture2D texture;

        public HelpTextComponent(Game game) : base(game)
        {
            this.game = game as Game1;
        }


        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


        protected override void LoadContent()
        {
           // texture = game.Content.Load<Texture2D>("Images/helpImage");
            base.LoadContent();
        }
    }
}
