using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledCS;

namespace quest_quiz.Core.World
{
    public class World : IDisposable
    {
        public Region Region;
        public Level Level;

        public World()
        {

        }

        public void LoadRegion()
        {
            ZipArchive file = ZipFile.OpenRead(Path.Combine(Path.World, "arabic.zip"));
            var arabic1 = new StreamReader(file.Entries[0].Open()).ReadToEnd();
            var map = new TiledMap();
            map.ParseXml(arabic1);

            Region = new Region(this, map);

            var tile = new TiledTileset(Path.Combine(Path.World, "Road.tsx"));
        }

        public void GetLevel()
        {

        }
        public void Dispose()
        {
        }
    }
}
