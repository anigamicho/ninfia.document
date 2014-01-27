using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APSV
{
    class SelectBoxItem
    {
        private string myName;
        private int myNameIndex;
        private int myValue;
        private int myValueIndex;

        public SelectBoxItem(string myName, int myValue)
        {
            this.myName = myName;
            this.myValue = myValue;

        }

        public SelectBoxItem(string myName, int myValue, int myNameIndex, int myValueIndex)
        {
            this.myName = myName;
            this.myValue = myValue;
            this.myNameIndex = myNameIndex;
            this.myValueIndex = myValueIndex;
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

    }
}
