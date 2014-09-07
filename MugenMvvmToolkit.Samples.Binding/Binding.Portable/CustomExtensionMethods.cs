namespace Binding.Portable
{
    public static class CustomExtensionMethods
    {
        public static string ExtensionMethod(this string s, int param)
        {
            return "string from extension method " + s + " param from extension method " + param;
        }
    }
}