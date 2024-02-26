using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public int MaxEnergy;

    public int CurrentEnergy;

    public int DrawAmount;

    public override IEnumerator Recover()
    {
        CurrentEnergy = MaxEnergy;

        yield return StartCoroutine(CardController.Instance.Draw(DrawAmount)); 
    }
}
