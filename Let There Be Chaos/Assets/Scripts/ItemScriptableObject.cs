using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "Items")]
public class ItemScriptableObject : ScriptableObject
{
    public enum ItemType
    {
        Dust,
        Potion,
        Food,
        Other
    }

    public enum ReagentType
    {
        Primary,
        Secondary,
        NaN
    }
    public string itemName;
    public string description;
    public Sprite image;
    public int strength;
    public ItemType type;
    public ReagentType reagentType;

}
