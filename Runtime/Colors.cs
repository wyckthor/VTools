using UnityEngine;

namespace VHon
{
    public static class Colors
    {
        //===============================================================================================================================
        // Colors.Get("123456");
        // Colors.Get("123456", 0.9f);
        // ------------------------------------------------------------------------------------------------------------------------------
        public static Color Get(string hex, float alpha = 1)
        {
            uint hexValue = uint.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            // Extract the red, green, and blue components from the uint
            byte r = (byte)((hexValue >> 16) & 0xff);
            byte g = (byte)((hexValue >> 8) & 0xff);
            byte b = (byte)(hexValue & 0xff);

            // Convert the byte values to floats in the range [0, 1]
            float rf = r / 255f;
            float gf = g / 255f;
            float bf = b / 255f;

            return new Color(rf, gf, bf, alpha);
        }
        // ------------------------------------------------------------------------------------------------------------------------------
    }
}