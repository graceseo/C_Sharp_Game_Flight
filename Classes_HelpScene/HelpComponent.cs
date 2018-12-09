using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    class HelpTextComponent : DrawableGameComponent
    {
        Game1 game;
        Texture2D descripsionTexture;
        Texture2D keboardTexture;
        Texture2D currentHelpImage;

        public HelpTextComponent(Game game) : base(game)
        {
            this.game = game as Game1;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            descripsionTexture = game.Content.Load<Texture2D>("Images/helpFirst");
            keboardTexture = game.Content.Load<Texture2D>("Images/keyboard");
            currentHelpImage = descripsionTexture;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                currentHelpImage = keboardTexture;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                currentHelpImage = descripsionTexture;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.Draw(currentHelpImage, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
