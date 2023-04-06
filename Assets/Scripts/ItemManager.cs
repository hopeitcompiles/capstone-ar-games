using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<ARItem> items = new List<ARItem>();
    [SerializeField] GameObject container;
    [SerializeField] ItemContent itemContent;

    void Start()
    {
        GameManager.instance.OnItemsMenu += Instance_OnItemsMenu;
    }

    private void Instance_OnItemsMenu()
    {
        foreach (ARItem item in items)
        {
            ItemContent newItem;
            newItem = Instantiate(itemContent, container.transform);
            newItem.ItemName = item.itemName;
            newItem.ItemDescription = item.itemDescription;
            newItem.ItemSprite = item.itemImage;
            newItem.ItemModel = item.itemModel;
        }
        GameManager.instance.OnItemsMenu -= Instance_OnItemsMenu;
    }
}
