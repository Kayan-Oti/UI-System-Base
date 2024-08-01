using DG.Tweening;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private float _offScreenPosY, _moveDuration, _delayTime;
    [SerializeField] private Vector2 _distanceToAnimate = new Vector2(5, 5);
    private RectTransform _rectTransform;
    private Vector2 _defaultPos;
    private float _upOffset;
    private float _downOffset;
    private float _leftOffset;
    private float _rightOffset;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _defaultPos = _rectTransform.anchoredPosition;
        InitializeOffsetPostion();

        _rectTransform.transform.localPosition += new Vector3(0f,_distanceToAnimate.y, 0f);
    }

    private void InitializeOffsetPostion(){
        _upOffset = _defaultPos.y + _distanceToAnimate.y;
        _downOffset = _defaultPos.y - _distanceToAnimate.y;
        _rightOffset = _defaultPos.x + _distanceToAnimate.x;
        _leftOffset = _defaultPos.x - _distanceToAnimate.x;
    }

    [ContextMenu("Start animation")]
    public void StartAnimation(){
        _rectTransform.DOAnchorPosY(_defaultPos.y, _moveDuration).SetDelay(_delayTime);
    }

    [ContextMenu("Play animation")]
    public void PlayAnimation(){
        _rectTransform.DOAnchorPosX(_leftOffset, _moveDuration).SetDelay(_delayTime).SetEase(Ease.InBack);
    }
}