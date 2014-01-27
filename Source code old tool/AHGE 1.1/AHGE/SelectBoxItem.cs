using System;

public class SelectBoxItem
{
    private string myName;
    private int myNameIndex;
    private int myValue;
    private int myValueIndex;
    private string hge;
    private int hgeIndex;

    public SelectBoxItem(string myName, int myValue, string hge)
    {
        this.myName = myName;
        this.myValue = myValue;
        this.hge = hge;
    }

    public SelectBoxItem(string myName, int myValue, int myNameIndex, int myValueIndex , string hge, int hgeIndex)
    {
        this.myName = myName;
        this.myValue = myValue;
        this.myNameIndex = myNameIndex;
        this.myValueIndex = myValueIndex;
        this.hge = hge;
        this.hgeIndex = hgeIndex;
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

    public string hgev
    {
        get
        {
            return this.hge;
        }
        set
        {
            this.hge = value;
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