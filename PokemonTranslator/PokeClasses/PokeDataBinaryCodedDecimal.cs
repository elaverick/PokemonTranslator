using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator.PokeClasses
{
    internal class PokeDataBinaryCodedDecimal
    {
        private const int _size=3;

        private int _offset;

        public int Offset
        {
            get { return _offset; }
        }

        public int Value { get; set; }

        public void Decode(BinaryReader binReader)
        {
            binReader.BaseStream.Seek(Offset, SeekOrigin.Begin);

            byte[] bytes = binReader.ReadBytes(_size);

            Value = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                int highNibble = (bytes[i] >> 4) & 0xF; // Extract the high nibble (4 bits)
                int lowNibble = bytes[i] & 0xF; // Extract the low nibble (4 bits)

                Value = (Value * 100) + (highNibble * 10) + lowNibble;
            }
        }

        public PokeDataBinaryCodedDecimal(int offset)
        {
            _offset = offset;
        }
    }
}
