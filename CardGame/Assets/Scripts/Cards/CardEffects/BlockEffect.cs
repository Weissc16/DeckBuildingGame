using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEffect : CardEffect
{
    public int Amount;
    //states damage done in debug log.  Amount is fixed currently and input through tester.
    public override IEnumerator Apply(List<object> targets)
    {
        foreach (Object o in targets)
        {
            Unit unit = o as Unit;

            ModifiedValues modifiedValues = new ModifiedValues(Amount);
            ApplyModifier(modifiedValues, ModifierTags.GainBlock, StateMachine.Instance.CurrentUnit);


            Debug.LogFormat("Unit {0} gained {1} block", unit.name, modifiedValues.FinalValue);
            int currentBlock = unit.GetStatValue(StatType.Block);
            unit.SetStatValue(StatType.Block, currentBlock + modifiedValues.FinalValue);
            
            yield return null;
        }
        
        void ApplyModifier(ModifiedValues modifiedValue, ModifierTags tags, Unit unit)
        {
            TagModifier modifier = unit.Modify[(int)tags];
            if (modifier != null)
            {
                modifier(modifiedValue);
            }
        }

    }
}
