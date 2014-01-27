using System;
using System.Collections;
using Percobaan;

public class SelectBoxItemArrayList
{
    private ArrayList list = new ArrayList();

    public void Add(string myName, int myValue, string hge)
    {
        this.list.Add(new SelectBoxItem(myName, myValue,hge));
    }

    public ArrayList GetArrayList()
    {
        return this.list;
    }

    public int SearchByName(string name)
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            SelectBoxItem item = (SelectBoxItem)this.list[i];
            if (name.Equals(item.Name))
            {
                return item.Value;
            }
        }
        return -1;
    }

    public string SearchByValue(int value)
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            SelectBoxItem item = (SelectBoxItem)this.list[i];
            if (value == item.Value)
            {
                return item.Name;
            }
        }
        return string.Empty;
    }

    public string SearchByhge(int value)
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            SelectBoxItem item = (SelectBoxItem)this.list[i];
            if (value == item.Value)
            {
                return item.hgev;
            }
        }
        return string.Empty;
    }

    public void SetArrayList(ArrayList arrayList)
    {
        this.list = arrayList;
    }

    public int Count
    {
        get
        {
            return this.list.Count;
        }
    }
}