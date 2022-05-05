namespace quest_quiz.Core
{
    public static class Path
    {
        public static string BaseDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string World
        {
            get
            {
                return System.IO.Path.Combine(BaseDirectory, "regions");
            }
        }

        public static string Settings
        {
            get
            {
                return System.IO.Path.Combine(BaseDirectory, "settings.json");
            }
        }

        public static string TileSet
        {
            get
            {
                return System.IO.Path.Combine(BaseDirectory, "regions");
            }
        }

        public static string Combine(string path1, string path2)
        {
            return System.IO.Path.Combine(path1, path2);
        }
    }
}
