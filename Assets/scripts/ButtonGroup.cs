using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ButtonGroup : MonoBehaviour
{
    private List<Button> clickedButtons = new List<Button>(); // Ŭ���� ��ư�� ���� ����Ʈ

    public Button[] buttons;
    private int clickedCount;// Ŭ���� ��ư�� ��
    public int num;
    private List<int> loNum = new List<int>();
    public Button submit;
    public GameObject win;
    public GameObject lose;
    public GameObject img;


    //public GameObject check;
    //public bool checkBool = false;
    // Start is called before the first frame update

    private Button lastClickedButton; // ���������� Ŭ���� ��ư�� �����ϱ� ���� ����

    void Start()
    {
        
        // ��� ��ư�� ���� Ŭ�� �̺�Ʈ�� �߰��մϴ�.
        for (int i = 0; i < buttons.Length; i++)
        {
            // Ŭ���� ������ ��ư�� �����մϴ�.
            Button button = buttons[i];
            button.onClick.AddListener(() => Click(button));
        }
        //submit.onClick.AddListener(() => LottoSubmit());
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void  Click(Button clickedButton)
    {
        Text t = clickedButton.GetComponentInChildren<Text>();
        if (clickedButtons.Contains(clickedButton))
        {
            // �̹� Ŭ���� ��ư�� ���, Ŭ�� ��� ó��
            clickedButton.image.color = new Color(255f, 255f, 255f, 0f);
            clickedButtons.Remove(clickedButton);
            loNum.Remove(int.Parse(t.text));
        }
        else
        {
            // ���ο� ��ư�� Ŭ���� ���, Ŭ�� ó��
            clickedButton.image.color = new Color(0f, 0f, 0f, 1f);
            clickedButtons.Add(clickedButton);
            loNum.Add(int.Parse(t.text));
        }

        // Ŭ���� ��ư�� ���� �ټ� ���� ���� ����
        PerformActionForFiveClickedButtons();
        lastClickedButton = clickedButton; // ���������� Ŭ���� ��ư ������Ʈ
    }
    private void PerformActionForFiveClickedButtons()
    {
        if (clickedButtons.Count >= num)
        {
            // Ŭ���� ��ư�� 5�� �̻��̸�
            foreach (Button button in buttons)
            {
                if (!clickedButtons.Contains(button))
                {
                    // Ŭ���� ��ư�� �ƴ� ��ư���� ��Ȱ��ȭ
                    button.interactable = false;
                }
            }
        }
        else
        {
            // Ŭ���� ��ư�� 5�� �̸��̸� ��� ��ư�� ��ȣ �ۿ� �����ϰ� ����
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
