using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIGT
{
    class SelectBoxItem
    {
        private string myName;
        private int myNameIndex;
        private int myValue;
        private int myValueIndex;
        private string myPokemonSpe;
        private int myPokemonSpeIndex;
        private string my1;
        private int my1i;
        private string my2;
        private int my2i;

        public SelectBoxItem(string myPokemonSpe, string myName, int myValue, string my1, string my2)
        {
            this.myPokemonSpe = myPokemonSpe;
            this.myName = myName;
            this.myValue = myValue;
            this.my1 = my1;
            this.my2 = my2;
        }

        public SelectBoxItem(string myName, int myValue, int myNameIndex, int myValueIndex, string myPokemonSpe, int myPokemonSpeIndex, string my1, int my1i, string my2, int my2i)
        {
            this.myName = myName;
            this.myValue = myValue;
            this.myPokemonSpe = myPokemonSpe;
            this.myNameIndex = myNameIndex;
            this.myValueIndex = myValueIndex;
            this.myPokemonSpeIndex = myPokemonSpeIndex;
            this.my1 = my1;
            this.my1i = my1i;
            this.my2 = my2;
            this.my2i = my2i;

        }

        public override string ToString()
        {
            return this.Name;
        }

        public string Name
        {
            get
            {
                return this.myName;
            }
            set
            {
                this.myName = value;
            }
        }

        public string NameAndValue
        {
            get
            {
                return string.Format("{0} ({1:000})", this.Name, this.Value);
            }
        }

        public int Value
        {
            get
            {
                return this.myValue;

            }
            set
            {
                this.myValue = value;
            }
        }

        public string ValueAndName
        {
            get
            {
                return string.Format("{0:000}: {1}", this.Value, this.Name);
            }
        }

        public string Species
        {
            get
            {
                return this.myPokemonSpe;
            }
            set
            {
                this.myPokemonSpe = value;
            }
        }


        public string my1s
        {
            get
            {
                return this.my1
;
            }
            set
            {
                this.my1 = value;
            }
        }

        public string my2s
        {
            get
            {
                return this.my2;
            }
            set
            {
                this.my2 = value;
            }
        }
    }
}
