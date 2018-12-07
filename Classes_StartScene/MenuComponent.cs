using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    public class MenuComponent : DrawableGameComponent
    {
        Game1 game;

        SpriteFont regularFont;
        SpriteFont highlightFont;

        private List<string> menuItems;
        private int SelectedIndex { get; set; }
        private Vector2 position;

        private Color regularColor = Color.White;
        private Color hilightColor = Color.SkyBlue;

        private KeyboardState oldState;

        private Texture2D gameLogo;

        public MenuComponent(Game game, List<string> menuNames) : base(game)
        {
            this.game = game as Game1;
            menuItems = menuNames;
        }

        public override void Initialize()
        {
            // starting position of the menu items
            position = new Vector2((GraphicsDevice.Viewport.Width - 300) / 2,
                                      (GraphicsDevice.Viewport.Height + 250) / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // load the fonts we will be using for this menu
            regularFont = game.Content.Load<SpriteFont>("Fonts/regularFont");
            highlightFont = game.Content.Load<SpriteFont>("Fonts/hilightFont");
            gameLogo = game.Content.Load<Texture2D>("Images/logoWords");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                KeyboardState ks = Keyboard.GetState();
                if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
                {
                    SelectedIndex++;
                    if (SelectedIndex == menuItems.Count)
                    {
                        SelectedIndex = 0;
                    }
                }
                if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = menuItems.Count - 1;
                    }
                }
                oldState = ks;

				if (ks.IsKeyDown(Keys.Enter))
                {
                    SwitchScenesBasedOnSelection();
                }
            }
            base.Update(gameTime);
        }

        private void SwitchScenesBasedOnSelection()
        {
            game.HideAllScenes();

            switch ((MenuSelection)SelectedIndex)
            {
                case MenuSelection.StartGame:

                    game.Services.GetService<ActionScene>().Show();
                    break;
                case MenuSelection.Help:
                    game.Services.GetService<HelpScene>().Show();
                    break;
                case MenuSelection.Quit:
                    game.Exit();
                    break;
                case MenuSelection.HighScore:

                case MenuSelection.About:
                    game.Services.GetService<AboutScene>().Show();
                    break;
                default:
                    // for now there is nothing handling the other options
                    // we will simply show this screen again
                    game.Services.GetService<StartScene>().Show();
                    break;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = game.Services.GetService<SpriteBatch>();
            Vector2 tempPos = position;

            sb.Begin();
            sb.Draw(gameLogo, new Vector2(0, 0)); //to draw a game logo on this manu compoent

            for (int i = 0; i < menuItems.Count; i++)
            {
                SpriteFont activeFont = regularFont;
                Color activeColor = regularColor;

                // if the selection is the item we are drawing
                // made it a the special font and colour
                if (SelectedIndex == i)
                {
                    activeFont = highlightFont;
                    activeColor = hilightColor;
                }
                sb.DrawString(activeFont, menuItems[i], tempPos, activeColor);

                // update the position of next string
                tempPos.Y += regularFont.LineSpacing;
            }

            sb.End();

            base.Draw(gameTime);
        }

    }
}
