using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Button : UI_CustomUIComponent
{
    [SerializeField] private UI_Style _style;
    public UnityEvent OnClick;

    private Button _button;
    private TextMeshProUGUI _buttonText;

    public override void Setup()
    {
        _button = GetComponentInChildren<Button>();
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void Configure()
    {
        UI_ThemeSO theme = GetMainTheme();
        if(theme == null) return;

        ColorBlock cb = _button.colors;
        cb.normalColor = theme.GetBackgroundColor(_style);
        _button.colors = cb;

        _buttonText.color = theme.GetTextColor(_style);
    }

    public void Onclick(){
        OnClick.Invoke();
    }

}