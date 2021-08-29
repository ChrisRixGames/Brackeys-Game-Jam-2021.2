using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeScriptableObject", menuName = "Recipe")]
public class RecipeScriptableObject : ScriptableObject
{
    public ItemScriptableObject output;

    public ItemScriptableObject[] ingredients;

    public int priority;
}
