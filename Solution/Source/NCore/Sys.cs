namespace NCore
{
    public static class Sys
    {
        public static readonly IFormatting Formatting = new DefaultFormatting();

        public static readonly IStringConverter StringConverter = new StringConverter(Formatting);
    }
}