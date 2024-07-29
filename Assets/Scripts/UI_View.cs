using UnityEngine;
using UnityEngine.UI;

public class UI_View : UI_CustomUIComponent
{
    [SerializeField] private UI_ViewSO _viewData;

    [SerializeField] private GameObject _headerContainer;
    [SerializeField] private UI_Style _headerStyle;
    [SerializeField] private GameObject _bodyContainer;
    [SerializeField] private UI_Style _bodyStyle;
    [SerializeField] private GameObject _footerContainer;
    [SerializeField] private UI_Style _footerStyle;

    private Image _headerImage;
    private Image _bodyImage;
    private Image _footerImage;

    private VerticalLayoutGroup _verticalLayoutGroup;

    public override void Setup(){
        _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        _headerImage = _headerContainer.GetComponent<Image>();
        _bodyImage = _bodyContainer.GetComponent<Image>();
        _footerImage = _footerContainer.GetComponent<Image>();
    }

    public override void Configure(){
        _verticalLayoutGroup.padding = _viewData.padding;
        _verticalLayoutGroup.spacing = _viewData.spacing;

        UI_ThemeSO theme = GetMainTheme();
        if(theme == null) return;

        _headerImage.color = theme.GetBackgroundColor(_headerStyle);
        _bodyImage.color = theme.GetBackgroundColor(_bodyStyle);
        _footerImage.color = theme.GetBackgroundColor(_footerStyle);
    }
}
