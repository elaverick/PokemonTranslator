using PokemonTranslator.PokeData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator.PokeClasses
{
    class PokeDataString
    {
        private const int _size=0xB;

        private int _offset;

        public int Offset
        {
            get { return _offset; }
        }

        public string Value { get; set; } = string.Empty;

        public void Decode(BinaryReader binReader)
        {
            binReader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            byte[] data = binReader.ReadBytes(_size);
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x50)
                {
                    data[i] = (byte)'\0';
                    break;
                }
                else
                    data[i] -= 63;
            }

            string decodedString = Encoding.ASCII.GetString(data);
            Value = decodedString.Substring(0, decodedString.IndexOf('\0'));
        }

        public PokeDataString(int offset)
        {
            _offset = offset;
        }
    }
}
