using PokemonTranslator.PokeData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator.PokeClasses
{
    class PokeDataList
    {
        private int _offset;

        public int Offset
        {
            get { return _offset; }
        }

        public List<ListEntry> Value { get; set; }

        public void Decode(BinaryReader binReader)
        {
            binReader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            byte count = binReader.ReadByte();
            for(byte i=0;i<count; i++)
            {
                byte itemIndex = binReader.ReadByte();
                byte itemCount = binReader.ReadByte();
                Value.Add(new ListEntry { Count = itemCount, Id = itemIndex });
            }
        }

        public PokeDataList(int offset)
        {
            _offset = offset;
            Value = new List<ListEntry>();
        }
    }
}
