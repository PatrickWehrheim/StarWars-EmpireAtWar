using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMenuBuilder
{
    public void Reset();
    public void BuildHeaderText(string text);
    public void BuildText(string text, int fontSize);
    public void BuildButton(string text, MenuType menuType);
    public Canvas GetResult();
}
