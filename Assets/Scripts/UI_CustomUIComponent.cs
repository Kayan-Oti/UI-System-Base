using UnityEngine;

public abstract class UI_CustomUIComponent : MonoBehaviour
{
    public UI_ThemeSO OverwriteTheme;

    void Start()
    {
        Init();
    }
    private void OnValidate() {
        Init();
    }

    public abstract void Setup();
    public abstract void Configure();

    [ContextMenu("Setup Refresh")]
    private void Init(){
        Setup();
        Configure();
    }  

    protected UI_ThemeSO GetMainTheme(){
        if(OverwriteTheme != null)
            return OverwriteTheme;
        if(UI_ThemeManager.Instance != null)
            return UI_ThemeManager.Instance.GetMainTheme();
        return null;
    }
}
