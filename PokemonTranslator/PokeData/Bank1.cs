using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonTranslator.PokeClasses;

namespace PokemonTranslator.PokeData
{
    internal class Bank1
    {
        PokeDataString playerName = new PokeDataString(0x2598);
        PokeDataDex pokemonOwned = new PokeDataDex(0x25A3);
        PokeDataDex pokemonSeen = new PokeDataDex(0x25B6);
        PokeDataList bagItems = new PokeDataList(0x25C9);
        PokeDataBinaryCodedDecimal money = new PokeDataBinaryCodedDecimal(0x25F3);
        PokeDataString rivalName = new PokeDataString(0x25F6);
        PokeDataBadges badges = new PokeDataBadges(0x2602);
    }
}
