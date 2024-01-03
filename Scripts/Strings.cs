namespace VHon
{
    public static class Strings
    {
        //===============================================================================================================================
        // "Text".Parse("Menu_");
        //===============================================================================================================================
        public static int Parse(this string _toParse, string _separator)
        {
            string[] separators = new string[] { _separator };
            string[] parsed = _toParse.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(parsed[0], out int number);
            return number;
        }

        //===============================================================================================================================
        // string[] parsed = "Text".ParseArray("/");
        //===============================================================================================================================
        public static string[] ParseArray(this string _toParse, string _separator)
        {
            return _toParse.Split(new string[] { _separator }, System.StringSplitOptions.RemoveEmptyEntries);
        }

        //===============================================================================================================================
        // "Text".HasPrefix("Prefix");
        //===============================================================================================================================
        public static bool HasPrefix(this string _toParse, string _text)
        {
            return (_toParse.Split('_'))[0] == _text;
        }

        //===============================================================================================================================
        // "Text".Italic();
        //===============================================================================================================================
        public static string Italic(this string text) => $"<i>{text}</i>";
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}