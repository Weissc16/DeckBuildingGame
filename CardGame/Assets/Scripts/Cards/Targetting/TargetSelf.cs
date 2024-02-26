using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelf : MonoBehaviour, ITarget
{
    public List<object> GetTargets()
    {
        List<object> targets = new List<object>();

        targets.Add(GetComponentInParent<Card>());
        return targets;
    }
}
