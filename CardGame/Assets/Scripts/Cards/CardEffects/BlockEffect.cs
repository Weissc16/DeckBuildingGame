using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEffect : MonoBehaviour, ICardEffect
{
    public int Amount;
    //states damage done in debug log.  Amount is fixed currently and input through tester.
    public IEnumerator Apply(List<object> targets)
    {
        foreach (Object o in targets)
        {
            Unit unit = o as Unit;
            Debug.LogFormat("Unit {0} gained {1} block", unit.name, Amount);
            int currentBlock = unit.GetStatValue(StatType.Block);
            unit.SetStatValue(StatType.Block, currentBlock + Amount);
            
            yield return null;
        }


    }
}
