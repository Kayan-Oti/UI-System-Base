using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Animation_Button : MonoBehaviour
{
    [Header("Container Setup")]
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _button;
    [SerializeField] private RectTransform _containerRectTransform;
    [SerializeField] private CanvasGroup _containerCanvasGroup;

    public enum AnimateToDirection{
        Top,
        Bottom,
        Left,
        Right
    }

    [Header("Animation Setup")]
    [SerializeField] private AnimateToDirection _openDirection = AnimateToDirection.Top;
    [SerializeField] private AnimateToDirection _closeDirection = AnimateToDirection.Bottom;
    [Space]
    [SerializeField] private Vector2 _distanceToAnimate = new Vector2(5, 5);
    [SerializeField] private AnimationCurve _easingCurve = AnimationCurve.EaseInOut(0,0,1,1);
    [Range(0, 1f)][SerializeField] private float _animationDuration = 0.5f;

    private bool _isOpen = false;
    [SerializeField] private Vector2 _initialPosition;
    [SerializeField] private Vector2 _currentPosition;
    [SerializeField] private Vector2 _upOffset;
    [SerializeField] private Vector2 _downOffset;
    [SerializeField] private Vector2 _leftOffset;
    [SerializeField] private Vector2 _rightOffset;
    private Coroutine _animateContainerCoroutine;

    private void OnValidate(){
        if(_container != null){
            _containerRectTransform = _container.GetComponent<RectTransform>();
            _containerCanvasGroup = _container.GetComponent<CanvasGroup>();
            _button = _container.GetComponentInChildren<Button>().gameObject;
        }

        _distanceToAnimate.x = Mathf.Max(0, _distanceToAnimate.x);
        _distanceToAnimate.y = Mathf.Max(0, _distanceToAnimate.y);

        _initialPosition = _containerRectTransform.anchoredPosition;
    }

    #region AnimationFuncionality

    private void Start(){
        _initialPosition = _containerRectTransform.anchoredPosition;

        InitializeOffsetPostion();
    }

    private void InitializeOffsetPostion(){
        _upOffset = new Vector2(0, _distanceToAnimate.y);
        _downOffset = new Vector2(0, -_distanceToAnimate.y);
        _rightOffset = new Vector2(_distanceToAnimate.y, 0);
        _leftOffset = new Vector2(-_distanceToAnimate.y, 0);
    }

    [ContextMenu("Toogle Open Close")]
    public void ToggleOpenClose(){
        if (_isOpen)
            CloseWindow();
        else
            OpenWindow();
    }

    public void OpenWindow(){
        if(_isOpen)
            return;

        _isOpen = true;
        // OnOpenWindow?.Invoke();

        if(_animateContainerCoroutine != null)
            StopCoroutine(_animateContainerCoroutine);

        _animateContainerCoroutine = StartCoroutine(AnimateWindow(true));
    }

    public void CloseWindow(){
        if(!_isOpen)
            return;

        _isOpen = false;
        // OnOpenWindow?.Invoke();

        if(_animateContainerCoroutine != null)
            StopCoroutine(_animateContainerCoroutine);

        _animateContainerCoroutine = StartCoroutine(AnimateWindow(false));
    }

    private Vector2 GetOffset(AnimateToDirection direction){
        switch(direction){
            case AnimateToDirection.Top:
                return _upOffset;
            case AnimateToDirection.Bottom:
                return _downOffset;
            case AnimateToDirection.Left:
                return _leftOffset;
            case AnimateToDirection.Right:
                return _rightOffset;
            default:
                return Vector2.zero;
        }
    }

    private IEnumerator AnimateWindow(bool open){
        if(open)
            _button.gameObject.SetActive(true);

        Vector2 targetPosition;
        float elapsedTime = 0;

        if(open)
        {
            targetPosition = _initialPosition;
            _containerRectTransform.anchoredPosition = _initialPosition + GetOffset(_openDirection);
            _currentPosition = _containerRectTransform.anchoredPosition;
        }            
        else{
            _currentPosition = _containerRectTransform.anchoredPosition;
            targetPosition = _currentPosition + GetOffset(_closeDirection);
        }

        while(elapsedTime < _animationDuration){
            float evaluationAtTime = _easingCurve.Evaluate(elapsedTime / _animationDuration);

            _containerRectTransform.anchoredPosition = Vector2.Lerp(_currentPosition, targetPosition, evaluationAtTime);

            _containerCanvasGroup.alpha = open ? Mathf.Lerp(0f,1f,evaluationAtTime) : Mathf.Lerp(1f,0f,evaluationAtTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _containerRectTransform.anchoredPosition = targetPosition;
        _containerCanvasGroup.alpha = open ? 1f: 0f;
        _containerCanvasGroup.blocksRaycasts = open;

        if(!open)
        {
            _button.gameObject.SetActive(false);
            _containerRectTransform.anchoredPosition = _initialPosition;
        }
    }

    #endregion
}
