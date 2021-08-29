using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]
    ItemScriptableObject itemAppearance;
    [SerializeField]
    ItemScriptableObject actualItem;
    // Start is called before the first frame update
    public Item(ItemScriptableObject appearance, ItemScriptableObject actual)
    {
        itemAppearance = appearance;
        actualItem = actual;
    }

    public void SetItemScriptableObjects(ItemScriptableObject appearance, ItemScriptableObject actual)
    {
        itemAppearance = appearance;
        actualItem = actual;
    }
    public ItemScriptableObject GetItemAppearance()
    {
        return itemAppearance;
    }

    public ItemScriptableObject GetActualItem()
    {
        return actualItem;
    }
}
