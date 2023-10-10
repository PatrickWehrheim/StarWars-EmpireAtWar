using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal static class MenuUtils
{
    private static Vector2 _normalButtonSize = new Vector2(160, 30);

    public static GameObject GetNewButton(string text, MenuType menuType)
    {
        //Initialise new GameObject with name and components
        GameObject gameObject = new GameObject(text + "Button");
        gameObject.AddComponent<CanvasRenderer>();
        gameObject.AddComponent<Button>();
        Image image = gameObject.AddComponent<Image>();
        ButtonBase buttonBase = gameObject.AddComponent<ButtonBase>();

        //Add nessesery things on components
        image.sprite = Resources.Load<Sprite>("UI/Skin/UISprite.psd");
        image.type = Image.Type.Sliced;
        buttonBase.MenuType = menuType;

        //Set text for the button
        GameObject buttonText = GetNewText(text, 20);
        buttonText.transform.SetParent(gameObject.transform);

        //Set transform of the button
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = _normalButtonSize;

        return gameObject;
    }

    public static GameObject GetNewText(string text, int fontSize)
    {
        GameObject gameObject = new GameObject(text);
        TextMeshProUGUI textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();
        textMeshPro.text = text;
        textMeshPro.fontSize = fontSize;
        textMeshPro.alignment = TextAlignmentOptions.Center;
        textMeshPro.color = Color.black;

        return gameObject;
    }

    public static Canvas ResetCanvas(Canvas canvas)
    {
        int count = canvas.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Object.Destroy(canvas.transform.GetChild(i).gameObject);
        }

        return canvas;
    }
}
