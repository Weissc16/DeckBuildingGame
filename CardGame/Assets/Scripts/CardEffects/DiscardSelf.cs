using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardSelf : MonoBehaviour, ICardEffect
{
    public void Apply()
    {
        CardController.Instance.Discard(GetComponentInParent<Card>());
    }
}
