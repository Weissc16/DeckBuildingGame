using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public int Duration;
    public int Amount;

    public bool StacksIntesnity;
    public bool StacksDuration;

    protected Unit _host;

    int _currentDuration;
    private void OnEnable()
    {
        _host = GetComponentInParent<Unit>();
        if(Duration > 0)
        {
            _currentDuration = Duration;
            _host.onUnitTakeTurn += DurationCountDown;
        }
        Invoke("OnInflicted", 1);
    }

    private void OnDisable()
    {
        OnRemoved();
    }

    public abstract void OnInflicted();
    public abstract void OnRemoved();

    public virtual void OnDurationEnded()
    {
        _host.onUnitTakeTurn -= DurationCountDown;
        Destroy(this.gameObject);
    }
    void DurationCountDown(Unit unit)
    {
        _currentDuration--;
        if (_currentDuration <= 0)
        {
            OnDurationEnded();
        }
    }
}
