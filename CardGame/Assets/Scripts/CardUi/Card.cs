using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    #region Properties/Fields
    public RectTransform Rect { get { return _rect; } }

    RectTransform _rect;

    Transform _back;
    Transform _front;

    int _movementTween;
    int _rotationTween;
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
        if (LeanTween.isTweening(gameObject) && LeanTween.isTweening(_movementTween))
        {
            LeanTween.cancel(_movementTween);
        }
       _movementTween = _rect.LeanMove(position, duration).setOnComplete(onComplete).id;
    }
    public void Rotate(float amount, float duration)
    {
        if (LeanTween.isTweening(gameObject) && LeanTween.isTweening(_rotationTween))
        {
            LeanTween.cancel(_rotationTween);
        }
        _rotationTween = _rect.LeanRotateAroundLocal(Vector3.up, amount, duration).id;
    }
    #endregion 
}
