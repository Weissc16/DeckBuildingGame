using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public static StateMachine Instance;
    public State Current { get { return _current; } }
    public Queue<Card> CardsToPlay;
    public Queue<Unit> Units;
    public Unit CurrentUnit;

    State _current;
    bool _busy;

    private void Awake()
    {
        Instance = this;
        CardsToPlay = new Queue<Card>();
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        ChangeState<LoadState>();
    }
    #region State Control

    public void ChangeState<T> () where T : State
    {
        State state = GetState<T>();
        if(state != null)
        {
            StartCoroutine(ChangeState(state));
        }
    }
    public T GetState<T> () where T:State{
        T target = GetComponent<T>();
        if(target == null)
        {
            target = gameObject.AddComponent<T>();
        }
        return target;
    }

    IEnumerator ChangeState(State state)
    {
        if (_busy)
        {
            yield break;
        }
        _busy = true;
        if (_current != null)
        {
            yield return StartCoroutine(_current.Exit());
        }
        _current = state;
        if (_current != null)
        {
            yield return StartCoroutine(_current.Enter());
        }
        _busy = false;
    }



    #endregion
}
