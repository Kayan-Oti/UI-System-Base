using UnityEngine;

public class UI_ThemeManager : MonoBehaviour
{
    [SerializeField] private UI_ThemeSO _mainTheme;

    public static UI_ThemeManager Instance;

    public void Awake(){
        Instance = this;
    }

    public UI_ThemeSO GetMainTheme(){
        return _mainTheme;
    }
}
