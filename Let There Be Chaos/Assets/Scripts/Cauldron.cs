using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject stirringRod;
    private Vector2 stirringRodStartPosition;
    private List<Item> ingredients = new List<Item>();

    private float strength = 0;
    private bool playerInteracting = false;
    private bool automated = false;
    private bool interacting;
    private float autoTime = 0f;
    private Coroutine interactionCoroutine;
    private PlayerScript player;

    [SerializeField]
    private RecipeScriptableObject[] recipes;

    public float currentProgress = 0;
    public float endProgress = 0;
    public float failPoint = 0;

    public void AddReagent(Item item)
    {
        ingredients.Add(item);
        endProgress += 5f;
    }

    public void BeginInteracting(PlayerScript play = null, bool playerAct = false)
    {
        player = play;
        if (ingredients.Count < 1 && !automated)
        {
            //play fail sound
            return;
        }
        playerInteracting = playerAct;
        if (!interacting)
        {
            interactionCoroutine = StartCoroutine(Interaction());
        }
        //throw new System.NotImplementedException();
    }

    public void Automate(float duration, float str)
    {
        automated = true;
        autoTime = duration;
        strength = str;
        BeginInteracting();
    }

    public void StopAutomate()
    {
        if (!playerInteracting)
        {
            StopInteracting();
        }
        strength = 0;
    }

    public void Fail()
    {
        throw new System.NotImplementedException();
    }

    public void Finish()
    {
        ItemScriptableObject output = CheckRecipes();
        if (output!= null)
        {
            player.PutItemInHand(new Item(output, output));
        }
        ingredients.Clear();
    }

    private ItemScriptableObject CheckRecipes()
    {
        foreach (RecipeScriptableObject recipe in recipes)
        {
            bool possibleRecipe = false;
            foreach (ItemScriptableObject itemSO in recipe.ingredients)
            {
                for (int i = 0; i < ingredients.Count; i++)
                {
                    Debug.Log(itemSO.name);
                    if (ingredients[i].GetActualItem() == itemSO)
                    {
                        possibleRecipe = true;
                        if (possibleRecipe)
                        {
                            //Debug.Log(ingredients[i].GetActualItem().name + " " + i);
                        }
                        break;
                    }
                    possibleRecipe = false;
                }
                if (!possibleRecipe)
                    break;
            }
            if (possibleRecipe)
            {
                return recipe.output;
            }
        }
        return null;
    }

    public void StopInteracting()
    {
        //throw new System.NotImplementedException();
        if (!automated)
        {
            StopCoroutine(interactionCoroutine);
            stirringRod.transform.position = stirringRodStartPosition;
        }
    }

    private IEnumerator Interaction()
    {
        interacting = true;

        Finish();
        interacting = false;
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        stirringRodStartPosition = stirringRod.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
