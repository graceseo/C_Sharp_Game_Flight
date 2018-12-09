using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class EndGameTextComponent : DrawableGameComponent
    {
        Game1 game;
        Texture2D gameOver;

        private Vector2 position;
        public EndGameTextComponent(Game game) : base(game)
        {
            this.game = game as Game1;
        }
        public override void Initialize()
        {
            position = new Vector2((GraphicsDevice.Viewport.Width -500) / 2,
                          (GraphicsDevice.Viewport.Height-200) / 2);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            gameOver=game.Content.Load<Texture2D>("Images/gameOver");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.Draw(gameOver, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
