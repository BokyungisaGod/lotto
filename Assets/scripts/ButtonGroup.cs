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

    private Button lastClickedButton; // ���������� Ŭ���� ��ư�� �����ϱ� ���� ����

    void Start()
    {
        //// ��� ��ư�� ���� Ŭ�� �̺�Ʈ�� �߰��մϴ�.
        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    // Ŭ���� ������ ��ư�� �����մϴ�.
        //    Button button = buttons[i];
        //    button.onClick.AddListener(() => Click(button));
        //}
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void Click(Button clickedButton)
    {
        checkBool = !checkBool;
        check.SetActive(checkBool);
        // ���������� Ŭ���� ��ư�� ���� Ŭ���� ��ư�� ������ Ȯ���մϴ�.
        if (lastClickedButton == clickedButton)
        {
            // �ٽ� Ŭ���� ��ư�� Ŭ���ϸ� ��� ��ư�� ��ȣ �ۿ� �����ϰ� �մϴ�.
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
            lastClickedButton = null; // ������ Ŭ�� ��ư�� null�� �����Ͽ� ���� Ŭ�� �� ��� ��ư�� ��ȣ �ۿ� �����ϵ��� �մϴ�.
        }
        else
        {
            // ���� Ŭ���� ��ư�� ������ ������ ��ư�� ��Ȱ��ȭ�մϴ�.
            foreach (Button button in buttons)
            {
                if (button != clickedButton)
                {
                    button.interactable = false;
                }
            }
            lastClickedButton = clickedButton; // ���������� Ŭ���� ��ư�� ���� Ŭ���� ��ư���� ������Ʈ�մϴ�.
        }
    }
}
