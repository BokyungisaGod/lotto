using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using NUnit.Framework;
using System;

public class select : MonoBehaviour
{
    private List<Button> clickedButtons = new List<Button>();

    public Button[] buttons;
    public Button[] cButtons;
    public int num;
    private List<int> loNum = new List<int>();
    private Animator anim;
    public int[] indexPos;
    public Button submitBtn;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];
            button.onClick.AddListener(() => Click(button));
        }
        for (int i = 0; i < cButtons.Length; i++)
        {
            Button button = cButtons[i];
            button.onClick.AddListener(() => backClick(button));
        }
        indexPos = new int[5];
    }

    public void Click(Button clickedButton)
    {
        clickedButtons.Add(clickedButton);
        for(int i=0;i<cButtons.Length; i++)
            if (!cButtons[i].interactable)
            {
                cButtons[i].image.color = new Color(255f, 255f, 255f, 1f);
                cButtons[i].interactable = true;
                indexPos[i] = Array.IndexOf(buttons, clickedButton);
                break;
            }     
        clickedButton.image.color = new Color(255f, 255f, 255f, 0f);
        clickedButton.interactable = false;
        PerformActionForFiveClickedButtons();
    }
    public void backClick(Button clickedButton)
    {
        int index = Array.IndexOf(cButtons, clickedButton);
        buttons[indexPos[index]].image.color = new Color(255f, 255f, 255f, 1f);
        clickedButton.image.color = new Color(255f, 255f, 255f, 0f);
        buttons[indexPos[index]].interactable = true;
        clickedButton.interactable = false;
        clickedButtons.Remove(buttons[indexPos[index]]);
        Debug.Log(index);
        PerformActionForFiveClickedButtons();
    }
    private void PerformActionForFiveClickedButtons()
    {
        if (clickedButtons.Count >= num)
        {
            foreach (Button button in buttons)
            {
                if (!clickedButtons.Contains(button))
                {
                    
                    button.interactable = false;
                }
            }
            submitBtn.interactable = true;
        }
        else
        {
            foreach (Button button in buttons)
            {
                
                button.interactable = true;
            }
            submitBtn.interactable = false;
        }
    }
}