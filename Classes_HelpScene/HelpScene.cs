using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GSeoFinalProject
{
    public class HelpScene : GameScene
    {
        public HelpScene(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            // create and add any components that belong to 
            // this scene to the Scene components list
            this.SceneComponents.Add(new HelpTextComponent(game));
            this.Hide();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    game.HideAllScenes();
                    game.Services.GetService<StartScene>().Show();
                }
            }
            base.Update(gameTime);
        }


    }
}
