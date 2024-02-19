using PokemonTranslator.PokeData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator.PokeClasses
{
    class PokeDataBadges
    {
        private const int _size=0xB;

        private int _offset;

        public int Offset
        {
            get { return _offset; }
        }

        public Badge[] Value { get; set; }

        public void Decode(BinaryReader binReader)
        {
            binReader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            byte data = binReader.ReadByte();

            for (int i = 0; i < 8; i++)
            {
                Value[i] = ((data >> (7 - i)) & 1) == 1 ? (Badge)(1 << i) : Badge.None;
            }
        }

        public PokeDataBadges(int offset)
        {
            _offset = offset;
            Value = new Badge[8];
        }
    }
}
