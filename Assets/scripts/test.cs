using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    [SerializeField]
    private int maxCount;
    [SerializeField]
    private int n;
    public Button[] buttons;
    public Color[] colors;
    private bool buttonClicked = false;

    private void Start()
    {
        //            ÿ            ڸ               
    }

    //          ư             ȣ  Ǵ   Լ 
    //public void OnOtherButtonClicked()
    //{
    //    int[] numbers = randomnumber.RandomNumbers(maxCount, n);

    //    //   ư  迭   ũ ⸸ŭ     ȸ ϸ                
    //    for (int i = 0; i < buttons.Length; i++)
    //    {
    //        Debug.Log($"{i + 1}  °      : {numbers[i]}");
    //        //   ư  ؽ Ʈ                 
    //        buttons[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
    //        SetButtonColor(buttons[i], numbers[i]);
    //    }
    //}
    //   ư   Ŭ        ȣ  Ǵ   Լ 
    public void OnButtonClicked()
    {
        if (!buttonClicked) // 버튼이 클릭되지 않았을 때만 실행
        {
            buttonClicked = true; // 버튼 클릭 상태로 설정
            SetRandomNumbersToButtons();
            Invoke("LoadLottoScene", n);
        }
    }

    // Button1, Button2, Button3, Button4, Button5                  ϴ   Լ 
    private void SetRandomNumbersToButtons()
    {
        int[] numbers = randomnumber.RandomNumbers(maxCount, buttons.Length);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            Debug.Log($"Button{i + 1}        : {numbers[i]}");
            buttons[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
            SetButtonColor(buttons[i], numbers[i]);
        }
    }

    public void SetButtonColor(Button button, int number)
    {
        if (number >= 1 && number <= 9)
        {
            button.image.color = colors[0];
        }
        else if (number >= 10 && number <= 19)
        {
            button.image.color = colors[1];
        }
        else if (number >= 20 && number <= 29)
        {
            button.image.color = colors[2];
        }
        else if (number >= 30 && number <= 39)
        {
            button.image.color = colors[3];
        }
        else if (number >= 40 && number <= 49)
        {
            button.image.color = colors[4];
        }
    }
    private void LoadLottoScene()
    {
        Debug.Log("Lotto          ȯ մϴ .");

        SceneManager.LoadScene("lotto");
    }
}