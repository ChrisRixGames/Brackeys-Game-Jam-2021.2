using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    Item item;

    private void Start()
    {
        if (item != null)
            SetImage();
    }

    public Item GetItem()
    {
        return item;
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        SetImage();
    }

    private void SetImage()
    {
        GetComponent<SpriteRenderer>().sprite = item.GetItemAppearance().image;
    }

    public void PickupItem(PlayerScript player)
    {
        player.PutItemInHand(item);
        Destroy(this.gameObject);
    }
}
