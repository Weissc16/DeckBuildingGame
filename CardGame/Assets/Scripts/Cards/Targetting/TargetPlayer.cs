using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour, ITarget
{
    public List<object> GetTargets()
    {
        List<object> targets = new List<object>();
        GameObject playerGameObject = GameObject.Find("Units/Player");
        targets.Add(playerGameObject.GetComponentInChildren<Unit>());
        return targets;
    }
}
