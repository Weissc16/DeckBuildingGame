using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Card Card;
    [ContextMenu("Draw")]
    void DrawCard()
    {
        CardController.Instance.Draw();
    }

    [ContextMenu("Discard")]
    void RemoveCard()
    {
        CardController.Instance.Discard(Card);
    }
    [ContextMenu("Shuffle")]
    void Shuffle()
    {
        CardController.Instance.ShuffleDiscardIntoDeck();
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
