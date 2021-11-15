using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader : MonoBehaviour
{
    public static JsonShopData jsonShopData;
    public TextAsset textFile;
    public Shelf shelfPrefab;
    public ItemData[] itemDatas;
    private void Awake()
    {
        LoadData();

    }

    private void Start()
    {
        LoadItem();
    }
    public void LoadItem()
    {
        //  ClearShelf();
        StartCoroutine(DoLoadItemToShop());
    }

    private void LoadData()
    {
        jsonShopData = JsonUtility.FromJson<JsonShopData>(textFile.text);
        Debug.LogError(jsonShopData.itemDatas.Length);
        itemDatas = jsonShopData.itemDatas;

    }

    IEnumerator DoLoadItemToShop()
    {
        for (int i = 0; i < 333; i++)
        {
            Shelf newShelf = Instantiate(shelfPrefab,transform);
            for (int j = 0; j < 3; j++)
            {
                newShelf.AddItem(itemDatas[i * 3 + j]);
            }
            Debug.Log(i);
            yield return null;
        }
    }

    public void ClearShelf()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform oldShelf = transform.GetChild(i);
            oldShelf.SetParent(null);
            Destroy(oldShelf.gameObject);
        }

    }
}

[System.Serializable]
public class JsonShopData
{
    public ItemData[] itemDatas;


}

[System.Serializable]
public class ItemData
{
    public int id;
    public string icon;
    public string title;
    public string desc;
    public int price;

    public ItemData() { }

    public ItemData(int id, string iconId, string title, string desc, int price)
    {
        this.id = id;
        this.icon = iconId;
        this.title = title;
        this.desc = desc;
        this.price = price;
    }
}