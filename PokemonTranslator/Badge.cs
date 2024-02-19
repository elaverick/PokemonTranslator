using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator
{
    public enum Badge
    {
        None = 0,
        Boulder = 1 << 7,   // MSB - Boulder Badge
        Cascade = 1 << 6,
        Thunder = 1 << 5,
        Rainbow = 1 << 4,
        Soul = 1 << 3,
        Marsh = 1 << 2,
        Volcano = 1 << 1,
        Earth = 1        // LSB - Earth Badge
    }

}
