namespace GameStore.App.Infrastructure
{
    public static class StringExtensions
    {
        public static string Shortify(this string input, int length)
        {
            if (input == null)
            {
                return input;
            }

            return input.Length > length ? $"{input.Substring(length)}..." : input;
        }
    }
}
