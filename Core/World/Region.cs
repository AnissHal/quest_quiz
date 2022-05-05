using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledCS;

namespace quest_quiz.Core.World
{
    public class Region : IDisposable
    {
        public IDictionary<string, Level> Levels;
        public TiledMap RegionMap;
        public World World;

        public Region(World world, TiledMap region)
        {
            World = world;
            RegionMap = region;
        }

        public void GetLevel()
        {

        }

        public void Dispose()
        {

        }
    }
}
