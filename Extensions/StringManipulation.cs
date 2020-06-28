namespace Extensions
{
    public static class StringManipulation
    {
        public static string RemoveQuotes(this string input)
        {
            return input.Replace("\"", "");
        }
    }
}
