using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
    private List<Button> clickedButtons = new List<Button>(); // 클릭된 버튼을 담을 리스트

    public Button[] buttons;
    private int clickedCount;// 클릭된 버튼의 수
    public int num;

    //public GameObject check;
    //public bool checkBool = false;
    // Start is called before the first frame update

    private Button lastClickedButton; // 마지막으로 클릭된 버튼을 추적하기 위한 변수

    void Start()
    {
        // 모든 버튼에 대해 클릭 이벤트를 추가합니다.
        for (int i = 0; i < buttons.Length; i++)
        {
            // 클로저 변수로 버튼을 저장합니다.
            Button button = buttons[i];
            button.onClick.AddListener(() => Click(button));
        }

    }

    // 버튼 클릭 시 호출되는 함수
    public void  Click(Button clickedButton)
    {
        if (clickedButtons.Contains(clickedButton))
        {
            // 이미 클릭된 버튼인 경우, 클릭 취소 처리
            clickedButton.image.color = Color.white;
            clickedButtons.Remove(clickedButton);
        }
        else
        {
            // 새로운 버튼을 클릭한 경우, 클릭 처리
            clickedButton.image.color = Color.black;
            clickedButtons.Add(clickedButton);
        }

        // 클릭된 버튼의 수가 다섯 개일 때의 동작
        PerformActionForFiveClickedButtons();
        lastClickedButton = clickedButton; // 마지막으로 클릭된 버튼 업데이트
    }
    private void PerformActionForFiveClickedButtons()
    {
        if (clickedButtons.Count >= num)
        {
            // 클릭된 버튼이 5개 이상이면
            foreach (Button button in buttons)
            {
                if (!clickedButtons.Contains(button))
                {
                    // 클릭된 버튼이 아닌 버튼들을 비활성화
                    button.interactable = false;
                }
            }
        }
        else
        {
            // 클릭된 버튼이 5개 미만이면 모든 버튼을 상호 작용 가능하게 설정
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
        }
    }
}
