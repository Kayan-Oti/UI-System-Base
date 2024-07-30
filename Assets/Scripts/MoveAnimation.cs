using DG.Tweening;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private float _topPosY, _moveDuration, _delayTime;
    private RectTransform _rectTransform;
    private float _defaultPosY;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _defaultPosY = _rectTransform.anchoredPosition.y;
        _rectTransform.transform.localPosition = new Vector3(0f,_topPosY, 0f);
        _rectTransform.DOAnchorPosY(_defaultPosY, _moveDuration).SetDelay(_delayTime);
    }
}