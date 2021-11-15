using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Sprite image;
    public string itemName;
    public int price;
    public string desc;
    public int id;

    public Image itemImage;
    public Text itemNameTxt;
    public Text itempriceTxt;
    internal void SetInfo(ItemData itemData)
    {
        price = itemData.price;
        itemName = itemData.title;
        image = Resources.Load<Sprite>("ShopItems/" + itemData.icon);
        id = itemData.id;
        desc = itemData.desc;


        itemImage.sprite = image;
        itempriceTxt.text = "" + price;
        itemNameTxt.text = itemName;
    }

    public void OnSelect()
    {
        ItemDetailPopup.instance.gameObject.SetActive(true);
        ItemDetailPopup.instance.ShowUp(this);
    }
}
