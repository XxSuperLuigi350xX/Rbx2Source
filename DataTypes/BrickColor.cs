﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Rbx2Source.DataTypes
{
    public class BrickColor
    {
        public readonly int Number;
        public readonly string Name;
        public readonly Color Color;

        public byte R => Color.R;
        public byte G => Color.G;
        public byte B => Color.B;

        public override string ToString() => Name;

        private static IReadOnlyList<BrickColor> ByPalette;
        private static IReadOnlyDictionary<int, BrickColor> ByNumber;

        private static Random RNG = new Random();

        private const string DefaultName = "Medium stone grey";
        private const int DefaultNumber = 194;

        internal BrickColor(int number, uint rgb, string name)
        {
            int r = (int)(rgb / 65536) % 256;
            int g = (int)(rgb / 256) % 256;
            int b = (int)(rgb % 256);

            Name = name;
            Number = number;

            Color = Color.FromArgb(r, g, b);
        }

        static BrickColor()
        {
            ByNumber = BrickColors.ColorMap.ToDictionary(brickColor => brickColor.Number);
            ByPalette = BrickColors.PaletteMap.Select(number => ByNumber[number]).ToList();
        }
        
        public static BrickColor FromName(string name)
        {
            BrickColor result = null;
            var query = BrickColors.ColorMap.Where((brickColor) => name == brickColor.Name);

            if (query.Count() > 0)
                result = query.First();
            else
                result = FromName(DefaultName);

            return result;
        }

        public static BrickColor FromNumber(int number)
        {
            if (!ByNumber.ContainsKey(number))
                number = DefaultNumber;

            return ByNumber[number];
        }

        public static bool TryFromNumber(int number, out BrickColor color)
        {
            bool valid = ByNumber.ContainsKey(number);
            color = (valid ? FromNumber(number) : null);

            return valid;
        }

        public static explicit operator BrickColor(int brickColorId)
        {
            return FromNumber(brickColorId);
        }

        public static BrickColor Random()
        {
            int index = RNG.Next(ByPalette.Count);
            return ByPalette[index];
        }

        public static BrickColor Palette(int index)
        {
            if (index < 0 || index >= ByPalette.Count)
                throw new Exception("Palette index was out of range.");

            return ByPalette[index];
        }

        public static BrickColor White()    => FromName("White");
        public static BrickColor Gray()     => FromName("Medium stone grey");
        public static BrickColor DarkGray() => FromName("Dark stone grey");
        public static BrickColor Black()    => FromName("Black");
        public static BrickColor Red()      => FromName("Bright red");
        public static BrickColor Yellow()   => FromName("Bright yellow");
        public static BrickColor Green()    => FromName("Dark green");
        public static BrickColor Blue()     => FromName("Bright blue");
    }

    public static class BrickColors
    {
        public static readonly int[] PaletteMap = new int[128]
        {
             141,  301,  107,   26, 1012,  303, 1011,  304,
              28, 1018,  302,  305,  306,  307,  308, 1021,
             309,  310, 1019,  135,  102,   23, 1010,  312,
             313,   37, 1022, 1020, 1027,  311,  315, 1023,
            1031,  316,  151,  317,  318,  319, 1024,  314,
            1013, 1006,  321,  322,  104, 1008,  119,  323,
             324,  325,  320,   11, 1026, 1016, 1032, 1015,
             327, 1005, 1009,   29,  328, 1028,  208,   45,
             329,  330,  331, 1004,   21,  332,  333,   24,
             334,  226, 1029,  335,  336,  342,  343,  338,
            1007,  339,  133,  106,  340,  341, 1001,    1,
               9, 1025,  337,  344,  345, 1014,  105,  346,
             347,  348,  349, 1030,  125,  101,  350,  192,
             351,  352,  353,  354, 1002,    5,   18,  217,
             355,  356,  153,  357,  358,  359,  360,   38,
             361,  362,  199,  194,  363,  364,  365, 1003,
        };

        public static IReadOnlyList<BrickColor> ColorMap = new List<BrickColor>()
        {
            new BrickColor(   1, 0xF2F3F3, "White"),
            new BrickColor(   2, 0xA1A5A2, "Grey"),
            new BrickColor(   3, 0xF9E999, "Light yellow"),
            new BrickColor(   5, 0xD7C59A, "Brick yellow"),
            new BrickColor(   6, 0xC2DAB8, "Light green (Mint)"),
            new BrickColor(   9, 0xE8BAC8, "Light reddish violet"),
            new BrickColor(  11, 0x80BBDB, "Pastel Blue"),
            new BrickColor(  12, 0xCB8442, "Light orange brown"),
            new BrickColor(  18, 0xCC8E69, "Nougat"),
            new BrickColor(  21, 0xC4281C, "Bright red"),
            new BrickColor(  22, 0xC470A0, "Med. reddish violet"),
            new BrickColor(  23, 0x0D69AC, "Bright blue"),
            new BrickColor(  24, 0xF5CD30, "Bright yellow"),
            new BrickColor(  25, 0x624732, "Earth orange"),
            new BrickColor(  26, 0x1B2A35, "Black"),
            new BrickColor(  27, 0x6D6E6C, "Dark grey"),
            new BrickColor(  28, 0x287F47, "Dark green"),
            new BrickColor(  29, 0xA1C48C, "Medium green"),
            new BrickColor(  36, 0xF3CF9B, "Lig. Yellowich orange"),
            new BrickColor(  37, 0x4B974B, "Bright green"),
            new BrickColor(  38, 0xA05F35, "Dark orange"),
            new BrickColor(  39, 0xC1CADE, "Light bluish violet"),
            new BrickColor(  40, 0xECECEC, "Transparent"),
            new BrickColor(  41, 0xCD544B, "Tr. Red"),
            new BrickColor(  42, 0xC1DFF0, "Tr. Lg blue"),
            new BrickColor(  43, 0x7BB6E8, "Tr. Blue"),
            new BrickColor(  44, 0xF7F18D, "Tr. Yellow"),
            new BrickColor(  45, 0xB4D2E4, "Light blue"),
            new BrickColor(  47, 0xD9856C, "Tr. Flu. Reddish orange"),
            new BrickColor(  48, 0x84B68D, "Tr. Green"),
            new BrickColor(  49, 0xF8F184, "Tr. Flu. Green"),
            new BrickColor(  50, 0xECE8DE, "Phosph. White"),
            new BrickColor( 100, 0xEEC4B6, "Light red"),
            new BrickColor( 101, 0xDA867A, "Medium red"),
            new BrickColor( 102, 0x6E99CA, "Medium blue"),
            new BrickColor( 103, 0xC7C1B7, "Light grey"),
            new BrickColor( 104, 0x6B327C, "Bright violet"),
            new BrickColor( 105, 0xE29B40, "Br. yellowish orange"),
            new BrickColor( 106, 0xDA8541, "Bright orange"),
            new BrickColor( 107, 0x008F9C, "Bright bluish green"),
            new BrickColor( 108, 0x685C43, "Earth yellow"),
            new BrickColor( 110, 0x435493, "Bright bluish violet"),
            new BrickColor( 111, 0xBFB7B1, "Tr. Brown"),
            new BrickColor( 112, 0x6874AC, "Medium bluish violet"),
            new BrickColor( 113, 0xE5ADC8, "Tr. Medi. reddish violet"),
            new BrickColor( 115, 0xC7D23C, "Med. yellowish green"),
            new BrickColor( 116, 0x55A5AF, "Med. bluish green"),
            new BrickColor( 118, 0xB7D7D5, "Light bluish green"),
            new BrickColor( 119, 0xA4BD47, "Br. yellowish green"),
            new BrickColor( 120, 0xD9E4A7, "Lig. yellowish green"),
            new BrickColor( 121, 0xE7AC58, "Med. yellowish orange"),
            new BrickColor( 123, 0xD36F4C, "Br. reddish orange"),
            new BrickColor( 124, 0x923978, "Bright reddish violet"),
            new BrickColor( 125, 0xEAB892, "Light orange"),
            new BrickColor( 126, 0xA5A5CB, "Tr. Bright bluish violet"),
            new BrickColor( 127, 0xDCBC81, "Gold"),
            new BrickColor( 128, 0xAE7A59, "Dark nougat"),
            new BrickColor( 131, 0x9CA3A8, "Silver"),
            new BrickColor( 133, 0xD5733D, "Neon orange"),
            new BrickColor( 134, 0xD8DD56, "Neon green"),
            new BrickColor( 135, 0x74869D, "Sand blue"),
            new BrickColor( 136, 0x877C90, "Sand violet"),
            new BrickColor( 137, 0xE09864, "Medium orange"),
            new BrickColor( 138, 0x958A73, "Sand yellow"),
            new BrickColor( 140, 0x203A56, "Earth blue"),
            new BrickColor( 141, 0x27462D, "Earth green"),
            new BrickColor( 143, 0xCFE2F7, "Tr. Flu. Blue"),
            new BrickColor( 145, 0x7988A1, "Sand blue metallic"),
            new BrickColor( 146, 0x958EA3, "Sand violet metallic"),
            new BrickColor( 147, 0x938767, "Sand yellow metallic"),
            new BrickColor( 148, 0x575857, "Dark grey metallic"),
            new BrickColor( 149, 0x161D32, "Black metallic"),
            new BrickColor( 150, 0xABADAC, "Light grey metallic"),
            new BrickColor( 151, 0x789082, "Sand green"),
            new BrickColor( 153, 0x957977, "Sand red"),
            new BrickColor( 154, 0x7B2E2F, "Dark red"),
            new BrickColor( 157, 0xFFF67B, "Tr. Flu. Yellow"),
            new BrickColor( 158, 0xE1A4C2, "Tr. Flu. Red"),
            new BrickColor( 168, 0x756C62, "Gun metallic"),
            new BrickColor( 176, 0x97695B, "Red flip/flop"),
            new BrickColor( 178, 0xB48455, "Yellow flip/flop"),
            new BrickColor( 179, 0x898788, "Silver flip/flop"),
            new BrickColor( 180, 0xD7A94B, "Curry"),
            new BrickColor( 190, 0xF9D62E, "Fire Yellow"),
            new BrickColor( 191, 0xE8AB2D, "Flame yellowish orange"),
            new BrickColor( 192, 0x694028, "Reddish brown"),
            new BrickColor( 193, 0xCF6024, "Flame reddish orange"),
            new BrickColor( 194, 0xA3A2A5, "Medium stone grey"),
            new BrickColor( 195, 0x4667A4, "Royal blue"),
            new BrickColor( 196, 0x23478B, "Dark Royal blue"),
            new BrickColor( 198, 0x8E4285, "Bright reddish lilac"),
            new BrickColor( 199, 0x635F62, "Dark stone grey"),
            new BrickColor( 200, 0x828A5D, "Lemon metalic"),
            new BrickColor( 208, 0xE5E4DF, "Light stone grey"),
            new BrickColor( 209, 0xB08E44, "Dark Curry"),
            new BrickColor( 210, 0x709578, "Faded green"),
            new BrickColor( 211, 0x79B5B5, "Turquoise"),
            new BrickColor( 212, 0x9FC3E9, "Light Royal blue"),
            new BrickColor( 213, 0x6C81B7, "Medium Royal blue"),
            new BrickColor( 216, 0x904C2A, "Rust"),
            new BrickColor( 217, 0x7C5C46, "Brown"),
            new BrickColor( 218, 0x96709F, "Reddish lilac"),
            new BrickColor( 219, 0x6B629B, "Lilac"),
            new BrickColor( 220, 0xA7A9CE, "Light lilac"),
            new BrickColor( 221, 0xCD6298, "Bright purple"),
            new BrickColor( 222, 0xE4ADC8, "Light purple"),
            new BrickColor( 223, 0xDC9095, "Light pink"),
            new BrickColor( 224, 0xF0D5A0, "Light brick yellow"),
            new BrickColor( 225, 0xEBB87F, "Warm yellowish orange"),
            new BrickColor( 226, 0xFDEA8D, "Cool yellow"),
            new BrickColor( 232, 0x7DBBDD, "Dove blue"),
            new BrickColor( 268, 0x342B75, "Medium lilac"),
            new BrickColor( 301, 0x506D54, "Slime green"),
            new BrickColor( 302, 0x5B5D69, "Smoky grey"),
            new BrickColor( 303, 0x0010B0, "Dark blue"),
            new BrickColor( 304, 0x2C651D, "Parsley green"),
            new BrickColor( 305, 0x527CAE, "Steel blue"),
            new BrickColor( 306, 0x335882, "Storm blue"),
            new BrickColor( 307, 0x102ADC, "Lapis"),
            new BrickColor( 308, 0x3D1585, "Dark indigo"),
            new BrickColor( 309, 0x348E40, "Sea green"),
            new BrickColor( 310, 0x5B9A4C, "Shamrock"),
            new BrickColor( 311, 0x9FA1AC, "Fossil"),
            new BrickColor( 312, 0x592259, "Mulberry"),
            new BrickColor( 313, 0x1F801D, "Forest green"),
            new BrickColor( 314, 0x9FADC0, "Cadet blue"),
            new BrickColor( 315, 0x0989CF, "Electric blue"),
            new BrickColor( 316, 0x7B007B, "Eggplant"),
            new BrickColor( 317, 0x7C9C6B, "Moss"),
            new BrickColor( 318, 0x8AAB85, "Artichoke"),
            new BrickColor( 319, 0xB9C4B1, "Sage green"),
            new BrickColor( 320, 0xCACBD1, "Ghost grey"),
            new BrickColor( 321, 0xA75E9B, "Lilac"),
            new BrickColor( 322, 0x7B2F7B, "Plum"),
            new BrickColor( 323, 0x94BE81, "Olivine"),
            new BrickColor( 324, 0xA8BD99, "Laurel green"),
            new BrickColor( 325, 0xDFDFDE, "Quill grey"),
            new BrickColor( 327, 0x970000, "Crimson"),
            new BrickColor( 328, 0xB1E5A6, "Mint"),
            new BrickColor( 329, 0x98C2DB, "Baby blue"),
            new BrickColor( 330, 0xFF98DC, "Carnation pink"),
            new BrickColor( 331, 0xFF5959, "Persimmon"),
            new BrickColor( 332, 0x750000, "Maroon"),
            new BrickColor( 333, 0xEFB838, "Gold"),
            new BrickColor( 334, 0xF8D96D, "Daisy orange"),
            new BrickColor( 335, 0xE7E7EC, "Pearl"),
            new BrickColor( 336, 0xC7D4E4, "Fog"),
            new BrickColor( 337, 0xFF9494, "Salmon"),
            new BrickColor( 338, 0xBE6862, "Terra Cotta"),
            new BrickColor( 339, 0x562424, "Cocoa"),
            new BrickColor( 340, 0xF1E7C7, "Wheat"),
            new BrickColor( 341, 0xFEF3BB, "Buttermilk"),
            new BrickColor( 342, 0xE0B2D0, "Mauve"),
            new BrickColor( 343, 0xD490BD, "Sunrise"),
            new BrickColor( 344, 0x965555, "Tawny"),
            new BrickColor( 345, 0x8F4C2A, "Rust"),
            new BrickColor( 346, 0xD3BE96, "Cashmere"),
            new BrickColor( 347, 0xE2DCBC, "Khaki"),
            new BrickColor( 348, 0xEDEAEA, "Lily white"),
            new BrickColor( 349, 0xE9DADA, "Seashell"),
            new BrickColor( 350, 0x883E3E, "Burgundy"),
            new BrickColor( 351, 0xBC9B5D, "Cork"),
            new BrickColor( 352, 0xC7AC78, "Burlap"),
            new BrickColor( 353, 0xCABFA3, "Beige"),
            new BrickColor( 354, 0xBBB3B2, "Oyster"),
            new BrickColor( 355, 0x6C584B, "Pine Cone"),
            new BrickColor( 356, 0xA0844F, "Fawn brown"),
            new BrickColor( 357, 0x958988, "Hurricane grey"),
            new BrickColor( 358, 0xABA89E, "Cloudy grey"),
            new BrickColor( 359, 0xAF9483, "Linen"),
            new BrickColor( 360, 0x966766, "Copper"),
            new BrickColor( 361, 0x564236, "Dirt brown"),
            new BrickColor( 362, 0x7E683F, "Bronze"),
            new BrickColor( 363, 0x69665C, "Flint"),
            new BrickColor( 364, 0x5A4C42, "Dark taupe"),
            new BrickColor( 365, 0x6A3909, "Burnt Sienna"),
            new BrickColor(1001, 0xF8F8F8, "Institutional white"),
            new BrickColor(1002, 0xCDCDCD, "Mid gray"),
            new BrickColor(1003, 0x111111, "Really black"),
            new BrickColor(1004, 0xFF0000, "Really red"),
            new BrickColor(1005, 0xFFB000, "Deep orange"),
            new BrickColor(1006, 0xB480FF, "Alder"),
            new BrickColor(1007, 0xA34B4B, "Dusty Rose"),
            new BrickColor(1008, 0xC1BE42, "Olive"),
            new BrickColor(1009, 0xFFFF00, "New Yeller"),
            new BrickColor(1010, 0x0000FF, "Really blue"),
            new BrickColor(1011, 0x002060, "Navy blue"),
            new BrickColor(1012, 0x2154B9, "Deep blue"),
            new BrickColor(1013, 0x04AFEC, "Cyan"),
            new BrickColor(1014, 0xAA5500, "CGA brown"),
            new BrickColor(1015, 0xAA00AA, "Magenta"),
            new BrickColor(1016, 0xFF66CC, "Pink"),
            new BrickColor(1017, 0xFFAF00, "Deep orange"),
            new BrickColor(1018, 0x12EED4, "Teal"),
            new BrickColor(1019, 0x00FFFF, "Toothpaste"),
            new BrickColor(1020, 0x00FF00, "Lime green"),
            new BrickColor(1021, 0x3A7D15, "Camo"),
            new BrickColor(1022, 0x7F8E64, "Grime"),
            new BrickColor(1023, 0x8C5B9F, "Lavender"),
            new BrickColor(1024, 0xAFDDFF, "Pastel light blue"),
            new BrickColor(1025, 0xFFC9C9, "Pastel orange"),
            new BrickColor(1026, 0xB1A7FF, "Pastel violet"),
            new BrickColor(1027, 0x9FF3E9, "Pastel blue-green"),
            new BrickColor(1028, 0xCCFFCC, "Pastel green"),
            new BrickColor(1029, 0xFFFFCC, "Pastel yellow"),
            new BrickColor(1030, 0xFFCC99, "Pastel brown"),
            new BrickColor(1031, 0x6225D1, "Royal purple"),
            new BrickColor(1032, 0xFF00BF, "Hot pink"),
        };
    }
}