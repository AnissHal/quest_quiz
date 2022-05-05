using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace quest_quiz.Core.World
{
    public class Tile : IDisposable
    {
        public int X;
        public int Y;

        public int Size;

        public Texture2D Texture;

        public Tile(int x, int y, Texture2D texture)
        {
            X = x;
            Y = y;

            Size = 16;

            Texture = texture;
        }

        public Vector2 ToCoordinates()
        {
            return new Vector2(X * Size, Y * Size);
        }

        public void Dispose()
        {
            Texture = null;
        }

    }
}
