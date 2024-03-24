using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class buttonclick : MonoBehaviour
{
    public select selectbutton;
    public Image image;
    public Button button;
    bool isClicked;
    public void Start()
    {
        button = GetComponent<Button>();
        image = button.GetComponent<Image>();
    }
    public void candypick()
    {
        if (isClicked)
        {
            image.color = new Color(255, 255, 255);
            select.cnt -= 1;
        }
        else
        {
            image.color = new Color(180, 174, 174);
            select.cnt += 1;
            selectbutton.checkButton();
        }
    }
}
