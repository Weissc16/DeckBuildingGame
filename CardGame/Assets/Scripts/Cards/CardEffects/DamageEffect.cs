using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, ICardEffect
{
    public int Amount;
    //states damage done in debug log.  Amount is fixed currently and input through tester.
    public IEnumerator Apply(List<object> targets)
    { 
        foreach (Object o in targets)
        {
            Unit unit = o as Unit;

            int block = unit.GetStatValue(StatType.Block);
            int leftoverBlock = Mathf.Max(0, block - Amount);
            unit.SetStatValue(StatType.Block, leftoverBlock);

            int currentHP = unit.GetStatValue(StatType.HP);
            int leftoverDamage = Mathf.Max(0, Amount - block);
            unit.SetStatValue(StatType.HP, Mathf.Max(0, currentHP - leftoverDamage));

            Debug.LogFormat("Unit {0} HP went from {1} to {2}; block went from {3} to {4}", unit.name, currentHP, unit.GetStatValue(StatType.HP), block, leftoverBlock);
            yield return null;
        }
        

    }
}
