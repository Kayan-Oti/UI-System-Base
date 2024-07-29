using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/UI_ThemeSO", fileName = "UI_Theme")]
public class UI_ThemeSO : ScriptableObject
{
    [Header("Color1")]
    public Color color1_bg;
    public Color color1_text;
    [Header("Color2")]
    public Color color2_bg;
    public Color color2_text;
    [Header("Color3")]
    public Color color3_bg;
    public Color color3_text;
    [Header("Color4")]
    public Color color4_bg;
    public Color color4_text;
    [Header("Color5")]
    public Color color5_bg;
    public Color color5_text;
    [Header("Other")]
    public Color disable;

    public Color GetBackgroundColor(UI_Style style){
        switch (style){
            case UI_Style.Color1:
                return color1_bg;
            case UI_Style.Color2:
                return color2_bg;
            case UI_Style.Color3:
                return color3_bg;
            case UI_Style.Color4:
                return color4_bg;
            case UI_Style.Color5:
                return color5_bg;
        }
        return disable;
    }

    public Color GetTextColor(UI_Style style){
        switch (style){
            case UI_Style.Color1:
                return color1_text;
            case UI_Style.Color2:
                return color2_text;
            case UI_Style.Color3:
                return color3_text;
            case UI_Style.Color4:
                return color4_text;
            case UI_Style.Color5:
                return color5_text;
        }
        return disable;
    }
}
