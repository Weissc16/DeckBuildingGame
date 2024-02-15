using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, IPlayed
{
    public int Amount;
    //states damage done in debug log.  Amount is fixed currently and input through tester.
    public void Apply()
    {
        Debug.LogFormat("Deals {0} damage", Amount);
    }
}
