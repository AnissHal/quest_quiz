using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TiledCS;

namespace quest_quiz.Core.Rendering
{
    public class TextureManager
    {
        private ContentManager Content;


        private IDictionary<string, Texture2D> LoadedTextures = new Dictionary<string, Texture2D>();

        public TextureManager(ContentManager content)
        {
            Content = content;

        }

        public void LoadTexturesFromLevel(TiledMap map)
        {
            foreach (TiledMapTileset tilesets in map.Tilesets)
            {
                TiledTileset tileset = new TiledTileset(Path.Combine(Path.TileSet, tilesets.source));

                LoadTexture(tileset);
            }

        }

        public Texture2D GetTexture(string key)
        {
            Texture2D texture = null;
            TryGetTexture(key, out texture);
            if (texture == null)
                throw new FileNotFoundException($"The texture '{key}' has not been found");
            return texture;
        }

        private bool TryGetTexture(string key, out Texture2D texture)
        {
            bool isTexture = LoadedTextures.ContainsKey(key);

            texture = null;

            if (isTexture)
            {
                texture = LoadedTextures[key];
            }

            return isTexture;
        }

        private void LoadTexture(TiledTileset tileset)
        {
            
            foreach(TiledTile tile in tileset.Tiles)
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(tile.image.source);
                Texture2D texture = Content.Load<Texture2D>($"assets/{filename}");
                LoadedTextures[filename] = texture;
            }  
        }



        public void UnloadTexture(string texture)
        {
            LoadedTextures[texture].Dispose();
            LoadedTextures.Remove(texture);
        }
    }

}
