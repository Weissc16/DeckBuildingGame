using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardHolder : MonoBehaviour
{
    public const float CardMoveDuration = 0.5f;
    public const float CardRotateDuration = 0.5f;

    public List<Card> Cards;

    public RectTransform Holder;

    public Text CardAmount;

    public int CardRotation;


    // Start is called before the first frame update
    void Awake()
    {
        Cards = new List<Card>();
        CardAmount.text = "" + Cards.Count;


    }

    public void AddCard(Card card)
    {
        //creating a 3D rectangle object called "rect" and setting it equal to the specified cards position, rotation and scale (aka transform)
        RectTransform rect = card.transform as RectTransform;
        //takes the 3D rectangle shape called "rect" and sets the Min/Max anchor and pivot to the same transform as the Holder object.=
        rect.anchorMax = Holder.anchorMax;
        rect.anchorMin = Holder.anchorMin;
        rect.pivot = Holder.pivot;
        CardHolder oldHolder = card.GetComponentInParent<CardHolder>();
        rect.SetParent(this.transform);


        card.Rotate(oldHolder.CardRotation - CardRotation, CardRotateDuration);
        card.Move(Holder.anchoredPosition3D, CardMoveDuration, () =>
        {
            Cards.Add(card);
            CardAmount.text = "" + Cards.Count;
            card.transform.SetParent(Holder);
        });
    }

    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
        CardAmount.text = ""+Cards.Count;
    }


    //rotates the cards upsidedown at start of game for Deck/Discard
    public void SetInitialRotation()
    {
        foreach(Card card in Cards)
        {
            RectTransform rect = card.transform as RectTransform;
            rect.rotation = Quaternion.Euler(0, CardRotation, 0);
        }
    }
}
