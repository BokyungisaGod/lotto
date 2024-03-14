using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
    private List<Button> clickedButtons = new List<Button>(); // Ŭ���� ��ư�� ���� ����Ʈ

    public Button[] buttons;
    private int clickedCount;// Ŭ���� ��ư�� ��
    public int num;

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

    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void  Click(Button clickedButton)
    {
        if (clickedButtons.Contains(clickedButton))
        {
            // �̹� Ŭ���� ��ư�� ���, Ŭ�� ��� ó��
            clickedButton.image.color = Color.white;
            clickedButtons.Remove(clickedButton);
        }
        else
        {
            // ���ο� ��ư�� Ŭ���� ���, Ŭ�� ó��
            clickedButton.image.color = Color.black;
            clickedButtons.Add(clickedButton);
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
}
