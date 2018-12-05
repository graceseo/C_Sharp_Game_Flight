using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class EndGameTextComponent : DrawableGameComponent
    {
        Game1 game;

        SpriteFont notificationFont;

        string pressWord = "Press ESC key....";

        private Vector2 position;
        public EndGameTextComponent(Game game) : base(game)
        {
            this.game = game as Game1;
        }


        public override void Initialize()
        {
            position = new Vector2((GraphicsDevice.Viewport.Width - 300) / 2,
                          (GraphicsDevice.Viewport.Height+400) / 2);

            base.Initialize();
        }
        protected override void LoadContent()

        {
            notificationFont = game.Content.Load<SpriteFont>("Fonts/notificationFont");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.DrawString(notificationFont, pressWord, position, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
