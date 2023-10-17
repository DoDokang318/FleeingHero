using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<DataItem> items = new List<DataItem>();

    public void AddItem(DataItem new_item)
    {
        items.Add(new_item);
        Debug.Log(" 아이템을 얻었습니다. : " + new_item.item.m_name);
    }

    public void RemoveItem(DataItem removed_item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item.m_name == removed_item.item.m_name)
            {
                Debug.Log(" 사용되었습니다. : " + items[i].item.m_name);
                items.RemoveAt(i);
            }
        }
    }
    public DataItem searchItem(DataItem searchItem)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].item.m_name == searchItem.item.m_name)
            {
                return items[i];
            }
        }
        return null;
    }
}
