using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public int MaxEnergy;

    public int CurrentEnergy;

    public int DrawAmount;
    public int MaxCards;


    public override IEnumerator Recover()
    {
        CurrentEnergy = MaxEnergy;
        int cardsToDraw = Mathf.Min(MaxCards - CardController.Instance.Hand.Cards.Count, DrawAmount);
        yield return StartCoroutine(CardController.Instance.Draw(cardsToDraw)); 
    }
}
