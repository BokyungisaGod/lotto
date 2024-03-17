using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ButtonGroup : MonoBehaviour
{
    private List<Button> clickedButtons = new List<Button>();

    public Button[] buttons;
    private int clickedCount;
    public int num;
    private List<int> loNum = new List<int>();
    public Button submit;
    public GameObject win;
    public GameObject lose;
    public GameObject img;


    //public GameObject check;
    //public bool checkBool = false;
    // Start is called before the first frame update

    private Button lastClickedButton;

    void Start()
    {
        
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];
            button.onClick.AddListener(() => Click(button));
        }
        //submit.onClick.AddListener(() => LottoSubmit());
    }

    public void  Click(Button clickedButton)
    {
        Text t = clickedButton.GetComponentInChildren<Text>();
        if (clickedButtons.Contains(clickedButton))
        {
            clickedButton.image.color = new Color(255f, 255f, 255f, 0f);
            clickedButtons.Remove(clickedButton);
            loNum.Remove(int.Parse(t.text));
        }
        else
        {
            clickedButton.image.color = new Color(0f, 0f, 0f, 1f);
            clickedButtons.Add(clickedButton);
            loNum.Add(int.Parse(t.text));
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
    public void LottoSubmit() 
    {
        int i = 0;
        //Debug.Log(loNum);
        while (i < 5)
        {
            if (loNum.Contains(test.numbers[i]))
            {
                i++;
            }
            else
            {
                break;
            }
        }
        if (i == 5)
        {
            Debug.Log("win");
            img.SetActive(true);
            win.SetActive(true);
        }
        else
        {
            Debug.Log("lose");
            img.SetActive(true);
            lose.SetActive(true);
        }
    }
}
