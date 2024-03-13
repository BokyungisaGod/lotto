using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
    public Button[] buttons;
    public GameObject check;
    public bool checkBool = false;
    // Start is called before the first frame update

    private Button lastClickedButton; // 마지막으로 클릭된 버튼을 추적하기 위한 변수

    void Start()
    {
        //// 모든 버튼에 대해 클릭 이벤트를 추가합니다.
        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    // 클로저 변수로 버튼을 저장합니다.
        //    Button button = buttons[i];
        //    button.onClick.AddListener(() => Click(button));
        //}
    }

    // 버튼 클릭 시 호출되는 함수
    public void Click(Button clickedButton)
    {
        checkBool = !checkBool;
        check.SetActive(checkBool);
        // 마지막으로 클릭된 버튼과 현재 클릭된 버튼이 같은지 확인합니다.
        if (lastClickedButton == clickedButton)
        {
            // 다시 클릭된 버튼을 클릭하면 모든 버튼을 상호 작용 가능하게 합니다.
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
            lastClickedButton = null; // 마지막 클릭 버튼을 null로 설정하여 다음 클릭 시 모든 버튼이 상호 작용 가능하도록 합니다.
        }
        else
        {
            // 현재 클릭된 버튼을 제외한 나머지 버튼은 비활성화합니다.
            foreach (Button button in buttons)
            {
                if (button != clickedButton)
                {
                    button.interactable = false;
                }
            }
            lastClickedButton = clickedButton; // 마지막으로 클릭된 버튼을 현재 클릭된 버튼으로 업데이트합니다.
        }
    }
}
