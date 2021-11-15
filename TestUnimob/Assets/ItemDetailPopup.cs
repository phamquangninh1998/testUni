using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailPopup : MonoBehaviour
{
    public Image itemImage;
    public Text itemNameTxt;
    public Text itemDes;

    public static ItemDetailPopup instance;
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowUp(ShopItem shopItem)
    {
        itemImage.sprite = shopItem.image;
        itemNameTxt.text = shopItem.itemName;
        itemDes.text = shopItem.desc;
    }
    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}
