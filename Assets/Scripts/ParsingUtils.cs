using System.Globalization;

abstract class ParsingUtils
{
    public static float StringToFloat(string str)
    {
        return float.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
    }
}