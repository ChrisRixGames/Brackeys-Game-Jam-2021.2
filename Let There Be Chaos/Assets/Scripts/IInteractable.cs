using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void AddReagent(Item item);

    void Automate(float duration, float str);

    void StopAutomate();

    void BeginInteracting(PlayerScript play, bool playerAct);

    void StopInteracting();

    void Finish();

    void Fail();
}
