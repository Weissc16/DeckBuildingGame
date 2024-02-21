using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTester : MonoBehaviour
{
    public Card Card;

    private void Start()
    {
        StartCoroutine(CardController.Instance.Draw(5));
    }
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
    [ContextMenu("Play")]
    void Play()
    {
        CardController.Instance.PlayedEffects(Card);
    }    [ContextMenu("AfterPlay")]
    void AfterPlay()
    {
        CardController.Instance.AfterPlayedEffects(Card);
    }

}
