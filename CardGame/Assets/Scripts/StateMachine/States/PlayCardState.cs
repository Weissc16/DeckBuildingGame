using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCardState : State
{
    Button endTurnButton;

    public override IEnumerator Enter()
    {
        EndTurnButton(true);
        yield return null;
    }
    
    public override IEnumerator Exit()
    {
        EndTurnButton(false);
        yield return null;
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