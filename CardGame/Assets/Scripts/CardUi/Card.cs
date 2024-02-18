using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    #region Properties/Fields
    RectTransform _rect;

    Transform _back;
    Transform _front;

    LTDescr _movementTween;
    LTDescr _rotationTween;
    #endregion

    #region Unity Events
    // Start is called before the first frame update
    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _back = transform.Find("Back");
        _front = transform.Find("Front");
    }

    // Update is called once per frame
    void Update()
    {
        if(_rect.rotation.eulerAngles.y > 90 && _rect.rotation.eulerAngles.y < 270)
        {
            _back.SetAsLastSibling();
        } else
        {
            _front.SetAsLastSibling();
        }
    }
    #endregion

    #region Methods
    public void Move(Vector3 position, float duration, System.Action onComplete)
    {
        if (_movementTween != null)
        {
            LeanTween.cancel(_movementTween.id);
        }
       _movementTween = _rect.LeanMove(position, duration).setOnComplete(onComplete);
    }
    public void Rotate(float amount, float duration)
    {
        if (_rotationTween != null)
        {
            LeanTween.cancel(_rotationTween.id);
        }
        _rotationTween = _rect.LeanRotateAroundLocal(Vector3.up, amount, duration);
    }
    #endregion 
}
