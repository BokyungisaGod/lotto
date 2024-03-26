using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class select : MonoBehaviour
{
    private List<Button> clickedButtons = new List<Button>();

    public Button[] buttons;
    public int num;
    private List<int> loNum = new List<int>();
    private Button lastClickedButton;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];
            button.onClick.AddListener(() => Click(button));
        }
    }

    public void Click(Button clickedButton)
    {
        if (clickedButtons.Contains(clickedButton))
        {
            clickedButton.image.color = new Color(255f, 255f, 255f, 1f);
            clickedButtons.Remove(clickedButton);
        }
        else
        {
            clickedButton.image.color = new Color(255f, 255f, 255f, 0.4f);
            clickedButtons.Add(clickedButton);
        }

        PerformActionForFiveClickedButtons();
        lastClickedButton = clickedButton;
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
        }
        else
        {
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
        }
    }
}
