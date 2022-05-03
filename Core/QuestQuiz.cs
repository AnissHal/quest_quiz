using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using quest_quiz.Core.Input;

namespace quest_quiz.Core
{
    public class QuestQuiz : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch _spriteBatch;

        private Texture2D _playerTexture;
        private Rectangle _playerPosition;

        private KeyboardHandler keyboardHandler;

        public QuestQuiz ()
        {
            Window.Title = "Quest Quiz";
            Graphics = new GraphicsDeviceManager(this);
            keyboardHandler = new(this);
            Components.Add(keyboardHandler);
        }

        protected override void Initialize()
        {

            _spriteBatch = new SpriteBatch(Graphics.GraphicsDevice);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;

            base.Initialize();

            _playerPosition = new Rectangle(10, 10, _playerTexture.Width, _playerTexture.Height);

            keyboardHandler.KeyDown += OnKeyDown;

        }

        private void OnKeyDown (object? sender, KeyboardHandlerEventArgs args)
        {
            
        }

        protected override void LoadContent()
        {
            _playerTexture = Content.Load<Texture2D>("player");

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            Graphics.GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_playerTexture, _playerPosition, Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                keyboardHandler.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}
