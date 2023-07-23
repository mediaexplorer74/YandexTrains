using System.Collections.Generic;
using System.Linq;
using Windows.UI;

namespace YandexTrains.Utilities
{
    public static class HexToRgb
    {
        public static Color HexToColor(string hex)
        {
            string hexString = default;

            //TEMP
            //hexString = hex[0] == '#' ? hex.TrimStart('#') : hex;


            uint value = 200;//uint.Parse(hexString, System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(
                a: 0xFF, 
                r: (byte)((value >> 16) & 0xFF), 
                g: (byte)((value >> 8) & 0xFF), 
                b: (byte)(value & 0xFF)
            );
        }
    }
}
