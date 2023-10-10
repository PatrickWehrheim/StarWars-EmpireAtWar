using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMenuBuilder : IMenuBuilder
{
    private Canvas _result;

    public ChooseMenuBuilder(Canvas canvas)
    {
        _result = canvas;
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public void BuildHeaderText(string text)
    {
        throw new System.NotImplementedException();
    }
    public void BuildText(string text, int fontSize)
    {
        throw new System.NotImplementedException();
    }

    public void BuildButton(string text, MenuType menuType)
    {
        GameObject button = MenuUtils.GetNewButton(text, menuType);
        button.transform.parent = _result.transform;
    }

    public Canvas GetResult()
    {
        throw new System.NotImplementedException();
    }
}
