using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] shopItems; //For putting items inside via the inspector
    private Hashtable items; //For efficiency - hashtable constant look up time

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        items.Clear();
        items = new Hashtable();

        for (int i = 0; i < shopItems.Length; i++)
        {
            items.Add(i, shopItems);
        }
    }

    public void AddItem(ShopItem shopItem)
    {
        items.Add(items.Count, shopItem);
    }

    public void RemoveItemAtIndex(int index)
    {
        if (hasItemAtIndex(index))
        {
            items.Remove(index);
            return;
        }

        LogIndexWarning(index);
    }

    public void OverrideItemAtIndex(int index, ShopItem shopItem)
    {
        if (hasItemAtIndex(index))
        {
            items[index] = shopItem;
            return;
        }

        LogIndexWarning(index);
    }

    public ShopItem GetItemAt(int index)
    {
        if (hasItemAtIndex(index))
        {
            return (ShopItem)items[index];
        }

        LogIndexWarning(index);
        return null;
    }

    public bool hasItemAtIndex(int index)
    {
        return items.ContainsKey(index);
    }

    public bool hasItem(ShopItem shopItem)
    {
        return items.ContainsValue(shopItem);
    }

    public Hashtable GetAllItems()
    {
        return items;
    }

    public void LogIndexWarning(int index)
    {
        Debug.LogWarning("Shop item at index " + index + " does not exist.", gameObject);
    }
}
