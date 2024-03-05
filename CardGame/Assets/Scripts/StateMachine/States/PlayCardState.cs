using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCardState : State
{
    public const string PlayedGameObject = "Effects/Played";
    public const string AfterPlayedGameObject = "Effects/AfterPlayed";

    Button endTurnButton;

    Coroutine cardSequencer;

    HorizontalLayoutGroup _handLayout;

    private void Awake()
    {
        _handLayout = CardController.Instance.Hand.Holder.GetComponent<HorizontalLayoutGroup>();
    }


    public override IEnumerator Enter()
    {
        yield return new WaitForSeconds(0.5f);
        EndTurnButton(true);
        _handLayout.enabled = false;
        cardSequencer = StartCoroutine(CardSequencer());
    }
    
    public override IEnumerator Exit()
    {
        yield return null;
        EndTurnButton(false);
        _handLayout.enabled = true;
        StopCoroutine(cardSequencer);
    }

    IEnumerator CardSequencer()
    {
        while (true)
        {
            if(machine.CardsToPlay.Count > 0)
            {
                Card card = machine.CardsToPlay.Dequeue();
                Debug.Log("Playing" + card);
                yield return StartCoroutine(PlayCardEffect(card, card.transform.Find(PlayedGameObject)));
                yield return new WaitForSeconds(0.2f);
                yield return StartCoroutine(PlayCardEffect(card, card.transform.Find(AfterPlayedGameObject)));
                yield return new WaitForSeconds(0.2f);
            }
            yield return null;
        }
    }

    IEnumerator PlayCardEffect(Card card, Transform playTransform)
    {
        for(int i=0; i<playTransform.childCount; i++)
        {
            ITarget targeter = playTransform.GetChild(i).GetComponent<ITarget>();
            List<object> targets = new List<object>();
            if (targeter == null)
            {
                continue;
            }
            yield return StartCoroutine(targeter.GetTargets(targets));
            foreach(CardEffect effect in playTransform.GetChild(i).GetComponents<CardEffect>())
            {
                yield return StartCoroutine(effect.Apply(targets));
            }
        }
    }

    void EndTurnButton(bool interactability)
    {
        if (endTurnButton == null)
        {
            endTurnButton = GameObject.Find("Canvas/EndTurnButton").GetComponent<Button>();
        }
        endTurnButton.interactable = interactability;
    }
}