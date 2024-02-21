using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, ICardEffect
{
    public int Amount;
    //states damage done in debug log.  Amount is fixed currently and input through tester.
    public void Apply()
    {
        List<object> targets = GetComponent<ITarget>().GetTargets();
        foreach (Object o in targets)
        {
            Unit unit = o as Unit;
            // unit.TakeDamage(Amount)
            Debug.LogFormat("Unit {0} took {1} damage", unit.name, Amount);
        }
        

    }
}
