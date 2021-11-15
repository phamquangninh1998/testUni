using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public Transform itemContainer;
    public ShopItem shopItemPrefab;

    private void Awake()
    {
       // ClearItems();
    }

    private void ClearItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform oldItem = transform.GetChild(i);
            oldItem.SetParent(null);
            Destroy(oldItem.gameObject);
        }
    }

    internal void AddItem(ItemData itemData)
    {
        ShopItem newShopItem = Instantiate(shopItemPrefab, itemContainer);
        newShopItem.SetInfo(itemData);
    }
}
