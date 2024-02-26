using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override IEnumerator Enter()
    {
        yield return StartCoroutine(InitializeDeck());
        yield return StartCoroutine(InitializeUnits());
        StartCoroutine(WaitThenChangeState<TurnBeginState>());
    }

    IEnumerator InitializeDeck()
    {
        foreach(Card card in CardController.Instance.PlayerDeck.Cards)
        {
            Card newCard = Instantiate(card, Vector3.zero, Quaternion.identity, CardController.Instance.Deck.Holder);
            CardController.Instance.Deck.AddCard(newCard);
        }
        yield return new WaitForSeconds(CardHolder.CardMoveDuration);
        CardController.Instance.Deck.SetInitialRotation();
    }

    IEnumerator InitializeUnits()
    {
        machine.Units = new Queue<Unit>();
        foreach(Unit unit in GameObject.Find("Units").GetComponentsInChildren<Unit>())
        {
            machine.Units.Enqueue(unit);
        }
        yield return null;
        Debug.Log(machine.Units.Count);
    }
}
