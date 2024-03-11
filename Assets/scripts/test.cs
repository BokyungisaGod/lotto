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

    private void Start()
    {
        // 최초 실행 시에는 랜덤 숫자를 설정하지 않음
    }

    // 나머지 버튼을 눌렀을 때 호출되는 함수
    //public void OnOtherButtonClicked()
    //{
    //    int[] numbers = randomnumber.RandomNumbers(maxCount, n);

    //    // 버튼 배열의 크기만큼만 순회하며 랜덤 숫자 설정
    //    for (int i = 0; i < buttons.Length; i++)
    //    {
    //        Debug.Log($"{i + 1}번째 난수 : {numbers[i]}");
    //        // 버튼 텍스트에 랜덤 숫자 설정
    //        buttons[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
    //        SetButtonColor(buttons[i], numbers[i]);
    //    }
    //}
    // 버튼을 클릭할 때 호출되는 함수
    public void OnButtonClicked()
    {
        // Button1, Button2, Button3, Button4, Button5에 랜덤 숫자 설정
        SetRandomNumbersToButtons();
        // n초 뒤에 lotto 씬으로 전환
        Invoke("LoadLottoScene", n);
    }

    // Button1, Button2, Button3, Button4, Button5에 랜덤 숫자 설정하는 함수
    private void SetRandomNumbersToButtons()
    {
        int[] numbers = randomnumber.RandomNumbers(maxCount, buttons.Length);

        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log($"Button{i + 1}의 난수 : {numbers[i]}");
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
        Debug.Log("Lotto 씬으로 전환합니다.");

        SceneManager.LoadScene("lotto");
    }
}
