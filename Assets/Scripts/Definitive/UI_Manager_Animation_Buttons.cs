using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_Animation_Buttons : MonoBehaviour
{
    //Propriets Inspector
    [SerializeField] private float _delayTimeBetween;
    [SerializeField] private List<UI_Animation_Button2> _listButtons = new List<UI_Animation_Button2>();


    public void Start()
    {
        GetListButtons();
    }

    [ContextMenu("Get List Buttons")]
    public void GetListButtons()
    {
        _listButtons.Clear();
        GetComponentsInChildren(_listButtons);
    }

    public IEnumerator StartAnimation(){
        foreach(UI_Animation_Button2 button in _listButtons)
        {
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(button.StartAnimation());
        }
    }
}