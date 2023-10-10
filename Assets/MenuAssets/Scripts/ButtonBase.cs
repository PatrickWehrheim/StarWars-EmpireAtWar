
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    public MenuType MenuType;

    private void Start()
    {
        UnityAction action = new UnityAction(OnClick);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        MenuController.Instance.ChangeMenu(MenuType);
    }
}
