using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardController : MonoBehaviour
{
    #region Fields/Properties
    public static CardController Instance;

    public CardHolder Hand;

    public CardHolder Deck;

    public CardHolder DiscardPile;

    public CardList PlayerDeck;
    #endregion
    #region Card Controls 
    void Awake()
    {
        Instance = this;
    }

    public IEnumerator Draw(int amount=1)
    {
        while (amount > 0) {
        if (Deck.Cards.Count == 0)
        {
            yield return StartCoroutine(ShuffleDiscardIntoDeck());
            yield return new WaitForSeconds(CardHolder.CardMoveDuration);
            if (Deck.Cards.Count == 0)
            {
                Debug.Log("Not enough cards to draw");
                yield break;
            }
        }
        Card card = Deck.Cards[Deck.Cards.Count - 1];
        Deck.RemoveCard(card);
        Hand.AddCard(card);
        amount--;
        yield return new WaitForSeconds(0.25f);
        }
    }

    public void Discard(Card card)
    {
        Hand.RemoveCard(card);
        Deck.RemoveCard(card);
        DiscardPile.AddCard(card);
    }

    public IEnumerator ShuffleDiscardIntoDeck()
    {
        List<Card> cards = DiscardPile.Cards;
        System.Random rand = new System.Random();
        List<Card> shuffled = new List<Card>(cards.OrderBy(x=> rand.Next()).ToList());
        foreach(Card card in shuffled)
        {
            DiscardPile.RemoveCard(card);
            Deck.AddCard(card);
            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion
    #region Card Events
    public void PlayedEffects(Card card)
    {
        Transform effectsHolder = card.transform.Find("Effects/Played");
        foreach(ICardEffect effect in effectsHolder.GetComponentsInChildren<ICardEffect>())
        {
            effect.Apply();
        }
    }    public void AfterPlayedEffects(Card card)
    {
        Transform effectsHolder = card.transform.Find("Effects/AfterPlayed");
        foreach (ICardEffect effect in effectsHolder.GetComponentsInChildren<ICardEffect>())
        {
            effect.Apply();
        }
    }
    #endregion

}
