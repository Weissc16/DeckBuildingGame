using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardEffect
{
    IEnumerator Apply(List<object> targets);
}
