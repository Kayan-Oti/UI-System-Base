using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UI_Animation_Button2 : UI_AbstractComponent_Animation
{
    //Propriets Inspector
    [SerializeField] private AnimationCurve _customEase;

    //Components
    private RectTransform _rectTransform;

    public override void Setup()
    {
        //Get Components
        _rectTransform = GetComponent<RectTransform>();

        _rectTransform.localScale = Vector2.zero;
    }

    [ContextMenu("Start animation")]
    public override IEnumerator StartAnimation(){
        _rectTransform.DOScale(1f, _animationDuration).SetEase(_customEase);
        yield return null;
    }
}
