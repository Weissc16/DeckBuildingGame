using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    public Card Card;

    public CardHolder CardHolder;
    [ContextMenu("Add")]
    void AddCard()
    {
        CardHolder.AddCard(Card);
    }

    [ContextMenu("Remove")]
    void RemoveCard()
    {
        CardHolder.RemoveCard(Card);
    }


}
