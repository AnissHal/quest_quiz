using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace quest_quiz.Core.Input.Control
{
    public class PlayerControl : IInput
    {
        QuestQuiz game;
        public PlayerControl(QuestQuiz game)
        {
            this.game = game;
        }

        public override bool KeyDown(GameTime gameTime, KeyboardHandlerEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.Right:
                    game._playerPosition.X += 1 * (int)(gameTime.ElapsedGameTime.TotalMilliseconds / 10);
                    return true;

                case Keys.Left:
                    game._playerPosition.X -= 1 * (int)(gameTime.ElapsedGameTime.TotalMilliseconds / 10);
                    return true;

                case Keys.Up:
                    game._playerPosition.Y -= 1 * (int)(gameTime.ElapsedGameTime.TotalMilliseconds / 10);
                    return true;

                case Keys.Down:
                    game._playerPosition.Y += 1 * (int)(gameTime.ElapsedGameTime.TotalMilliseconds / 10);
                    return true;

            }
            return false;
        }

        public override bool KeyUp(GameTime gameTime, KeyboardHandlerEventArgs e)
        {
            return base.KeyUp(gameTime, e);
        }
    }
}
