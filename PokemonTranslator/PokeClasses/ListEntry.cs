using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTranslator.PokeClasses
{
    struct ListEntry
    {
        private byte id;
        private byte count;

        public byte Id
        {
            get { return id; }
            set { id = value; }
        }

        public byte Count
        {
            get { return count; }
            set
            {
                if (value > 99)
                {
                    throw new ArgumentOutOfRangeException(nameof(Count), "Count cannot be higher than 99.");
                }
                count = value;
            }
        }
    }
}
