using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTester : MonoBehaviour
{
    public Card Card;

    [ContextMenu("Draw")]
    void DrawCard()
    {
        StartCoroutine(CardController.Instance.Draw());
    }

    [ContextMenu("Discard")]
    void RemoveCard()
    {
        CardController.Instance.Discard(Card);
    }
    [ContextMenu("Shuffle")]
    void Shuffle()
    {
        StartCoroutine(CardController.Instance.ShuffleDiscardIntoDeck());
    }
}
