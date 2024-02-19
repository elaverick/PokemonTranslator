using PokemonTranslator.PokeData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator.PokeClasses
{
    class PokeDataDex
    {
        private int _size=13;

        private int _offset;

        public int Offset
        {
            get { return _offset; }
        }

        public List<bool> Value { get; set; }

        public void Decode(BinaryReader binReader)
        {
            binReader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            byte[] data = binReader.ReadBytes(_size);

            int numPokemon = data.Length * 8; // Total number of bits in the array
            bool[] pokemonSeen = new bool[numPokemon];

            for (int i = 0; i < numPokemon; i++)
            {
                int byteIndex = i >> 3; // Equivalent to i / 8
                int bitIndex = i & 7;   // Equivalent to i % 8

                int bitValue = data[byteIndex] >> bitIndex & 1;
                pokemonSeen[i] = bitValue == 1;
            }

            Value.AddRange(pokemonSeen);
        }

        public PokeDataDex(int offset)
        {
            _offset = offset;
            Value = new List<bool>();
        }
    }
}
