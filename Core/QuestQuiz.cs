using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO.Compression;
using MonoGame.Extended;
using quest_quiz.Core.Input;
using quest_quiz.Core.Input.Control;
using TiledCS;
using Newtonsoft.Json;
using quest_quiz.Core.Rendering;

namespace quest_quiz.Core
{
    public class QuestQuiz : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch _spriteBatch;
        public GameTime GameTime;

        private Texture2D _playerTexture;
        public Rectangle _playerPosition;

        private KeyboardHandler keyboardHandler;
        private List<IInput> Controls;

        public TextureManager textureManager;
        public QuestQuiz ()
        {
            Window.Title = "Quest Quiz";
            Graphics = new GraphicsDeviceManager(this);
            keyboardHandler = new(this);
            Components.Add(keyboardHandler);
        }

        protected override void Initialize()
        {
            Controls = new List<IInput>();

            _spriteBatch = new SpriteBatch(Graphics.GraphicsDevice);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;

            base.Initialize();
            // After LoadContent

            _playerPosition = new Rectangle(10, 10, _playerTexture.Width, _playerTexture.Height);

            keyboardHandler.KeyDown += OnKeyDown;

            ZipArchive file = ZipFile.OpenRead(Path.Combine(Path.World, "arabic.zip"));
            var arabic1 = new StreamReader(file.Entries[0].Open()).ReadToEnd();
            var map = new TiledMap();
            map.ParseXml(arabic1);

            textureManager.LoadTexturesFromLevel(map);

            //_playerTexture = textureManager.GetTexture("bg");
            
            Controls.Add(new PlayerControl(this));
            
        }

        private void OnKeyDown (object? sender, KeyboardHandlerEventArgs args)
        {
            foreach (IInput control in Controls)
            {
                if (control.KeyDown(this.GameTime, args))
                    break;
            }
        }

        protected override void LoadContent()
        {
            
            _playerTexture = Content.Load<Texture2D>("assets/bg");

            textureManager = new TextureManager(Content);


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
            this.GameTime = gameTime;

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
