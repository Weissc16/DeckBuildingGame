using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    public Card Card;

    public CardController CardController;

    [ContextMenu("Draw")]
    void DrawCard()
    {
        CardController.Draw();
    }

    [ContextMenu("Discard")]
    void RemoveCard()
    {
        CardController.Discard(Card);
    }
    [ContextMenu("Shuffle")]
    void Shuffle()
    {
        CardController.ShuffleDiscardIntoDeck();
    }
    [ContextMenu("Play")]
    void Play()
    {
        CardController.PlayEffects(Card);
    }

}
