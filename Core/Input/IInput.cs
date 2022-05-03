using Microsoft.Xna.Framework;

namespace quest_quiz.Core.Input
{
    public abstract class IInput
    {
         public virtual bool KeyDown(GameTime gameTime, KeyboardHandlerEventArgs e)
        {
            return false;
        }

        public virtual bool KeyUp(GameTime gameTime, KeyboardHandlerEventArgs e)
        {
            return false;
        }
    }
}
