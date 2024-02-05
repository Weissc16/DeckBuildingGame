using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardHolder : MonoBehaviour
{

    public List<Card> Cards;

    public RectTransform Holder;

    public Text CardAmount;


    // Start is called before the first frame update
    void Awake()
    {
        Cards = new List<Card>();

    }

    public void AddCard(Card card)
    {
        Cards.Add(card);
        CardAmount.text = ""+Cards.Count;
        card.transform.SetParent(Holder);
    }

    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
        CardAmount.text = ""+Cards.Count;
    }
}
