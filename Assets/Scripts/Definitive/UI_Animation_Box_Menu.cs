using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UI_Animation_Box_Menu : UI_AbstractComponent_Animation
{
    //Propriets Inspector
    [SerializeField] private Vector2 _distanceToAnimate = new Vector2(300, 300);
    [SerializeField] private AnimationCurve _customEase;

    //Components
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    //Values
    private Vector2 _defaultPos;
    private float _upOffset;
    private float _downOffset;
    private float _leftOffset;
    private float _rightOffset;

    #region Setup

    public override void Setup()
    {
        //Get Components
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        //Set Values
        _defaultPos = _rectTransform.anchoredPosition;
        InitializeOffsetPostion();

        //Set Components
        _rectTransform.transform.localPosition += new Vector3(0f,_distanceToAnimate.y, 0f);
        _canvasGroup.alpha = 0f;
    }

    private void InitializeOffsetPostion(){
        _upOffset = _defaultPos.y + _distanceToAnimate.y;
        _downOffset = _defaultPos.y - _distanceToAnimate.y;
        _rightOffset = _defaultPos.x + _distanceToAnimate.x;
        _leftOffset = _defaultPos.x - _distanceToAnimate.x;
    }

    #endregion

    #region Animations

    [ContextMenu("Start animation")]
    public override IEnumerator StartAnimation(){
        Sequence startAnimationSequence = DOTween.Sequence();
        startAnimationSequence
            .Insert(1,_rectTransform.DOAnchorPosY(_defaultPos.y, _animationDuration).SetEase(_customEase))
            .Insert(1,_canvasGroup.DOFade(1f, _animationDuration));
        yield return startAnimationSequence.WaitForCompletion();
    }

    [ContextMenu("OnClick_Play")]
    public void OnClick_Play(){
        _rectTransform.DOAnchorPosX(_leftOffset, _animationDuration).SetEase(Ease.InBack);
    }

    #endregion
}