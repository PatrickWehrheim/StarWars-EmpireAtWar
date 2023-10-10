using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuBuilder : IMenuBuilder
{
    private Canvas _result;

    public MainMenuBuilder(Canvas canvas)
    {
        _result = canvas;
    }

    public void Reset()
    {
        _result = MenuUtils.ResetCanvas(_result);
    }

    public void BuildHeaderText(string text)
    {
        GameObject headText = MenuUtils.GetNewText(text, 26);
        headText.transform.SetParent(_result.transform);
    }

    public void BuildText(string text, int fontSize)
    {
        GameObject newText = MenuUtils.GetNewText(text, fontSize);
        newText.transform.SetParent(_result.transform);
    }

    public void BuildButton(string text, MenuType menuType)
    {
        GameObject button = MenuUtils.GetNewButton(text, menuType);
        button.transform.SetParent(_result.transform);
    }

    public Canvas GetResult()
    {
        Canvas result = _result;
        Reset();
        return result;
    }
}
