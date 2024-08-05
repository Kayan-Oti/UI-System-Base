using System.Collections;
using UnityEngine;

public abstract class UI_CustomComponent_Animation : MonoBehaviour
{
    [SerializeField] protected float _animationDuration;
    void Start()
    {
        Setup();
    }

    public abstract void Setup();

    [ContextMenu("Start animation")]
    public abstract IEnumerator StartAnimation();

}

