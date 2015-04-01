namespace Fletnix.Domain
{
    public static class CacheKeys
    {
        public const string Genres = "Genres";
        public const string MovieList = "Movies";

        public static string GenreById(int id)
        {
            return string.Format("Genre_{0}", id);
        }

        public static string MovieById(int id)
        {
            return string.Format("Movie_{0}", id);
        }

        public static string MovieIncludingGenresById(int id)
        {
            return string.Format("Movie_Genre_{0}", id);
        }
    }
}