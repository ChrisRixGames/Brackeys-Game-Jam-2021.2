using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void AddReagent(/*add reagent class*/);

    void Interact();

    void Finish();

    void Fail();

    float currentProgress
    {
        get;
        set;
    }

    float endProgress
    {
        get;
        set;
    }

    float failPoint
    {
        get;
        set;
    }
}
