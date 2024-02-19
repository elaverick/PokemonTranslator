using PokemonTranslator.PokeClasses;

namespace PokemonTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Pokemon Red (UE) [S][!].sav";

            using (BinaryReader binReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                PokeDataString playerName = new PokeDataString(0x2598);
                playerName.Decode(binReader);

                Console.WriteLine(playerName.Value);

                PokeDataString rivalName = new PokeDataString(0x25F6);
                rivalName.Decode(binReader);

                Console.WriteLine(rivalName.Value);

                PokeDataDex pokemonSeen = new PokeDataDex(0x25B6);
                pokemonSeen.Decode(binReader);

                PokeDataList bagItems = new PokeDataList(0x25C9);
                bagItems.Decode(binReader);

                PokeDataBinaryCodedDecimal money = new PokeDataBinaryCodedDecimal(0x25F3);
                money.Decode(binReader);

                Console.WriteLine("${0}", money.Value);

                PokeDataBadges badges = new PokeDataBadges(0x2602);
                badges.Decode(binReader);

                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine($"{badges.Value[i]} Badge: {(badges.Value[i] != Badge.None ? "Acquired" : "Not Acquired")}");
                }

                /*foreach(ListEntry listEntry in bagItems.Value)
                {
                    Console.WriteLine("{0} - {1}", listEntry.Count, Enum.GetName(typeof(Items),listEntry.Id).Replace('_',' '));
                }*/

                /*for (int i = 0; i< Enum.GetNames(typeof (Pokemon)).Length; i++) {
                    Console.WriteLine(Enum.GetName(typeof(Pokemon),i+1) + " - " + pokemonSeen.Value[i]);
                }*/
            }

        }
    }
}
