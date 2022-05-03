using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace quest_quiz.Core.Input
{
    public class KeyboardHandler : GameComponent
    {
        KeyboardState State;

        public event EventHandler<KeyboardHandlerEventArgs> KeyDown;

        public event EventHandler<KeyboardHandlerEventArgs> KeyUp;
        public KeyboardHandler(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            State = Keyboard.GetState();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();
            Handle(State, newState);
            base.Update(gameTime);
        }

        private void Handle(KeyboardState oldState, KeyboardState newState)
        {
            Keys[] currentKeys = newState.GetPressedKeys();
            Keys[] oldKeys = oldState.GetPressedKeys();

            var pressed = currentKeys.Except(oldKeys);
            var unpressed = oldKeys.Except(currentKeys);

            foreach (Keys Key in pressed)
            {
                var args = new KeyboardHandlerEventArgs(Key, true);
                KeyDown?.Invoke(this, args);
            }

            foreach (Keys Key in unpressed)
            {
                var args = new KeyboardHandlerEventArgs(Key, true);
                KeyUp?.Invoke(this, args);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                KeyDown = null;
                KeyUp = null;
            }
            base.Dispose(disposing);
        }
    }

    public class KeyboardHandlerEventArgs : EventArgs
    {
        public Keys Key { get; private set; }
        public bool IsPressed { get; private set; }

        public KeyboardHandlerEventArgs(Keys key, bool isPressed)
        {
            Key = key;
            IsPressed = isPressed;
        }
    }
}
