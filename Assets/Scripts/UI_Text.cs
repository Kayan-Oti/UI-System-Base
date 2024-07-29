using TMPro;
using UnityEngine;

public class UI_Text : UI_CustomUIComponent
{
    [SerializeField] private UI_TextSO _textData;
    [SerializeField] private UI_Style _style;

    private TextMeshProUGUI _textUI;

    public override void Setup(){
        _textUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void Configure(){
        UI_ThemeSO theme = GetMainTheme();
        if(theme == null) return;


        _textUI.color = theme.GetTextColor(_style);
        _textUI.font = _textData.font;
        _textUI.fontSize = _textData.fontSize;
    }
}